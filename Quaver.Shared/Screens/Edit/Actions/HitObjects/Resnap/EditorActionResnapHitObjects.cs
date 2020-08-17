using System;
using System.Collections.Generic;
using System.Linq;
using Quaver.API.Maps;
using Quaver.API.Maps.Structures;
using Quaver.Shared.Graphics.Notifications;
using Quaver.Shared.Screens.Edit.Actions.HitObjects.PlaceBatch;

namespace Quaver.Shared.Screens.Edit.Actions.HitObjects.RemoveBatch
{
    public class EditorActionResnapHitObjects : IEditorAction
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public EditorActionType Type { get; } = EditorActionType.ResnapHitObjects;

        /// <summary>
        /// </summary>
        private EditorActionManager ActionManager { get; }

        /// <summary>
        /// </summary>
        private Qua WorkingMap { get; }

        /// <summary>
        /// </summary>
        private List<int> Snaps { get; }

        /// <summary>
        ///     Unmodified notes, kept for undoing
        /// </summary>
        private List<HitObjectInfo> OldNotes { get; } = new List<HitObjectInfo>();

        /// <summary>
        ///     Modified notes, kept for undoing
        /// </summary>
        private List<HitObjectInfo> NewNotes { get; } = new List<HitObjectInfo>();

        /// <summary>
        /// </summary>
        /// <param name="actionManager"></param>
        /// <param name="workingMap"></param>
        /// <param name="hitObjects"></param>
        public EditorActionResnapHitObjects(EditorActionManager actionManager, Qua workingMap, List<int> snaps)
        {
            ActionManager = actionManager;
            WorkingMap = workingMap;
            Snaps = snaps;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void Perform()
        {

            var i = 0;

            // Using AudioEngine.GetNearestSnapTimeFromTime is unreliable since it might not return the current snap
            foreach (var tp in WorkingMap.TimingPoints)
            {
                var timingPointEnd = tp.StartTime + WorkingMap.GetTimingPointLength(tp);
                var msPerSnaps = Snaps.Select(s => tp.MillisecondsPerBeat / s).ToList();

                while (timingPointEnd > WorkingMap.HitObjects[i].StartTime)
                {
                    var note = WorkingMap.HitObjects[i];

                    float smallestDelta = WorkingMap.HitObjects.Last().StartTime;
                    foreach (var msPerSnap in msPerSnaps)
                    {
                        var deltaForward = (note.StartTime - tp.StartTime) % msPerSnap;
                        var deltaBackward = deltaForward - msPerSnap;
                        var delta = deltaForward < -deltaBackward ? deltaForward : deltaBackward;
                        if (Math.Abs(delta) < Math.Abs(smallestDelta))
                            smallestDelta = delta;
                    }

                    if (Math.Abs(smallestDelta) >= 1)
                    {
                        var newNote = Helpers.ObjectHelper.DeepClone(note);
                        newNote.StartTime = (int)(newNote.StartTime - smallestDelta);
                        if (newNote.EndTime > 0)
                            newNote.EndTime = (int)(newNote.EndTime - smallestDelta);

                        OldNotes.Add(note);
                        NewNotes.Add(newNote);
                    }

                    if (i < WorkingMap.HitObjects.Count)
                        i++;
                    else
                        break;
                }
            }

            if (OldNotes.Count() > 0)
            {
                OldNotes.ForEach(n => WorkingMap.HitObjects.Remove(n));
                WorkingMap.HitObjects.AddRange(NewNotes);
                WorkingMap.Sort();
                NotificationManager.Show(NotificationLevel.Info, $"Resnapped {NewNotes.Count} notes");
                ActionManager.TriggerEvent(EditorActionType.ResnapHitObjects, new EditorActionHitObjectsResnappedEventArgs(Snaps));
            }
            else
                NotificationManager.Show(NotificationLevel.Info, $"No notes to resnap");

        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void Undo()
        {
            NewNotes.ForEach(n => WorkingMap.HitObjects.Remove(n));
            WorkingMap.HitObjects.AddRange(OldNotes);
            WorkingMap.Sort();
        }
    }
}