﻿using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Wenzil.Console;

public class BeatmapParser : MonoBehaviour
{
    public static Beatmap Parse(string filePath)
    {
        if (!File.Exists(filePath.Trim()))
        {
            Beatmap tempBeatmap = new Beatmap();
            tempBeatmap.IsValid = false;

            return tempBeatmap;
        }

        Wenzil.Console.Console.Log("Success: Beatmap Found! Beginning to Parse.");

        // Create a new beatmap object and default the validity to true.
        Beatmap beatmap = new Beatmap();
        beatmap.IsValid = true;

        // This will hold the section of the beatmap that we are parsing.
        string section = "";

        foreach (string line in File.ReadAllLines(filePath))
        {
            switch(line.Trim())
            {
                case "[General]":
                    section = "[General]";
                    break;
                case "[Editor]":
                    section = "[Editor]";
                    break;
                case "[Metadata]":
                    section = "[Metadata]";
                    break;
                case "[Difficulty]":
                    section = "[Difficulty]";
                    break;
                case "[Events]":
                    section = "[Events]";
                    break;
                case "[TimingPoints]":
                    section = "[TimingPoints]";
                    break;
                case "[HitObjects]":
                    section = "[HitObjects]";
                    break;
            }

            // Parse osu! file format
            if (line.StartsWith("osu file format"))
            {
                beatmap.OsuFileFormat = line;
            }

            // Parse [General] Section
            if (section.Equals("[General]"))
            {
                if (line.Contains(":"))
                {
                    string key = line.Substring(0, line.IndexOf(':'));
                    string value = line.Split(':').Last();

                    switch (key.Trim())
                    {
                        case "AudioFilename":
                            beatmap.AudioFilename = value;
                            break;
                        case "AudioLeadIn":
                            beatmap.AudioLeadIn = Int32.Parse(value);
                            break;
                        case "PreviewTime":
                            beatmap.PreviewTime = Int32.Parse(value);
                            break;
                        case "Countdown":
                            beatmap.Countdown = Int32.Parse(value);
                            break;
                        case "SampleSet":
                            beatmap.SampleSet = value;
                            break;
                        case "StackLeniency":
                            beatmap.StackLeniency = float.Parse(value);
                            break;
                        case "Mode":
                            beatmap.Mode = Int32.Parse(value);
                            break;
                        case "LetterboxInBreaks":
                            beatmap.LetterboxInBreaks = Int32.Parse(value);
                            break;
                        case "SpecialStyle":
                            beatmap.SpecialStyle = Int32.Parse(value);
                            break;
                        case "WidescreenStoryboard":
                            beatmap.WidescreenStoryboard = Int32.Parse(value);
                            break;
                        
                    }
           
                }
                
            }

            // Parse [Editor] Data
            if (section.Equals("[Editor]"))
            {
                if (line.Contains(":"))
                {
                    string key = line.Substring(0, line.IndexOf(':'));
                    string value = line.Split(':').Last();

                    switch (key.Trim())
                    {
                        case "Bookmarks":
                            beatmap.Bookmarks = value;
                            break;
                        case "DistanceSpacing":
                            beatmap.DistanceSpacing = float.Parse(value);
                            break;
                        case "BeatDivisor":
                            beatmap.BeatDivisor = Int32.Parse(value);
                            break;
                        case "GridSize":
                            beatmap.GridSize = Int32.Parse(value);
                            break;
                        case "TimelineZoom":
                            beatmap.TimelineZoom = float.Parse(value);
                            break;
                    }
                }

            }

            // Parse [Editor] Data
            if (section.Equals("[Metadata]"))
            {
                if (line.Contains(":"))
                {
                    string key = line.Substring(0, line.IndexOf(':'));
                    string value = line.Split(':').Last();

                    switch (key.Trim())
                    {
                        case "Title":
                            beatmap.Title = value;
                            break;
                        case "TitleUnicode":
                            beatmap.TitleUnicode = value;
                            break;
                        case "Artist":
                            beatmap.Artist = value;
                            break;
                        case "ArtistUnicode":
                            beatmap.ArtistUnicode = value;
                            break;
                        case "Creator":
                            beatmap.Creator = value;
                            break;
                        case "Version":
                            beatmap.Version = value;
                            break;
                        case "Source":
                            beatmap.Source = value;
                            break;
                        case "Tags":
                            beatmap.Tags = value;
                            break;
                        case "BeatmapID":
                            beatmap.BeatmapID = Int32.Parse(value);
                            break;
                        case "BeatmapSetID":
                            beatmap.BeatmapSetID = Int32.Parse(value);
                            break;
                        default:
                            break;
                    }
                }

            }

            // Parse [Difficulty] Data
            if (section.Equals("[Difficulty]"))
            {
                if (line.Contains(":"))
                {
                    string key = line.Substring(0, line.IndexOf(':'));
                    string value = line.Split(':').Last();

                    switch (key.Trim())
                    {
                        case "HPDrainRate":
                            beatmap.HPDrainRate = float.Parse(value);
                            break;
                        case "CircleSize":
                            beatmap.KeyCount = Int32.Parse(value);
                            break;
                        case "OverallDifficulty":
                            beatmap.OverallDifficulty = float.Parse(value);
                            break;
                        case "ApproachRate":
                            beatmap.ApproachRate = float.Parse(value);
                            break;
                        case "SliderMultiplier":
                            beatmap.SliderMultiplier = float.Parse(value);
                            break;
                        case "SliderTickRate":
                            beatmap.SliderTickRate = float.Parse(value);
                            break;
                    }
                }

            }

            // Parse [Events] Data
            if (section.Equals("[Events]"))
            {
                // We only care about parsing the background path,
                // So there's no need to parse the storyboard data.
                if (line.Contains("png") || line.Contains("jpg") || line.Contains("jpeg"))
                {
                    string[] values = line.Split(',');
                    beatmap.Background = values[2];
                }
            }


        }

        return beatmap;
    }
}
