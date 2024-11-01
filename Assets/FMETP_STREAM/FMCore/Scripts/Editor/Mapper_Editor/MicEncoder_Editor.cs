﻿using System;
using UnityEngine;
using UnityEditor;
using FMSolution.Editor;

namespace FMSolution.FMETP
{
    [CustomEditor(typeof(MicEncoder))]
    [CanEditMultipleObjects]
    public class MicEncoder_Editor : UnityEditor.Editor
    {
        private MicEncoder MEncoder;

        SerializedProperty DeviceModeProp;
        SerializedProperty TargetDeviceNameProp;
        SerializedProperty DetectedDevicesProp;

        SerializedProperty StreamGameSoundProp;
        SerializedProperty OutputSampleRateProp;
        SerializedProperty OutputChannelsProp;


        SerializedProperty StreamFPSProp;
        SerializedProperty GZipModeProp;

        SerializedProperty OutputFormatProp;
        SerializedProperty OutputAsChunksProp;
        SerializedProperty OutputChunkSizeProp;
        SerializedProperty OnDataByteReadyEventProp;
        SerializedProperty OnRawPCM16ReadyEventProp;


        SerializedProperty labelProp;
        SerializedProperty dataLengthProp;

        private void OnEnable()
        {
            DeviceModeProp = serializedObject.FindProperty("DeviceMode");
            TargetDeviceNameProp = serializedObject.FindProperty("TargetDeviceName");
            DetectedDevicesProp = serializedObject.FindProperty("DetectedDevices");

            StreamGameSoundProp = serializedObject.FindProperty("StreamGameSound");
            OutputSampleRateProp = serializedObject.FindProperty("OutputSampleRate");
            OutputChannelsProp = serializedObject.FindProperty("OutputChannels");


            StreamFPSProp = serializedObject.FindProperty("StreamFPS");
            GZipModeProp = serializedObject.FindProperty("GZipMode");

            OutputFormatProp = serializedObject.FindProperty("OutputFormat");
            OutputAsChunksProp = serializedObject.FindProperty("OutputAsChunks");
            OutputChunkSizeProp = serializedObject.FindProperty("OutputChunkSize");
            OnDataByteReadyEventProp = serializedObject.FindProperty("OnDataByteReadyEvent");
            OnRawPCM16ReadyEventProp = serializedObject.FindProperty("OnRawPCM16ReadyEvent");

            labelProp = serializedObject.FindProperty("label");
            dataLengthProp = serializedObject.FindProperty("dataLength");
        }

        private bool drawSuccess = false;
        public override void OnInspectorGUI()
        {
            if (MEncoder == null) MEncoder = (MicEncoder)target;

            serializedObject.Update();


            GUILayout.Space(2);
            GUILayout.BeginVertical("box");
            {
                drawSuccess = FMCoreEditor.DrawHeader("Streaming Component");
                if (!MEncoder.EditorShowCapture || !drawSuccess)
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("+ Capture")) MEncoder.EditorShowCapture = true;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                }
                else
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("- Capture")) MEncoder.EditorShowCapture = false;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(StreamGameSoundProp, new GUIContent("Stream Game Sound"));
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(DeviceModeProp, new GUIContent("Device Mode"));
                        GUILayout.EndHorizontal();

                        if (MEncoder.DeviceMode != MicDeviceMode.Default)
                        {
                            GUILayout.BeginHorizontal();
                            EditorGUILayout.PropertyField(TargetDeviceNameProp, new GUIContent("Device Name"));
                            GUILayout.EndHorizontal();

                            GUILayout.BeginHorizontal();
                            EditorGUILayout.PropertyField(DetectedDevicesProp, new GUIContent("Detected Devices"));
                            GUILayout.EndHorizontal();
                        }
                    }
                    GUILayout.EndVertical();
                }
            }
            GUILayout.EndVertical();

            GUILayout.Space(2);
            GUILayout.BeginVertical("box");
            {
                if (!MEncoder.EditorShowAudioInfo || !drawSuccess)
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("+ Audio Info")) MEncoder.EditorShowAudioInfo = true;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                }
                else
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("- Audio Info")) MEncoder.EditorShowAudioInfo = false;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(OutputChannelsProp, new GUIContent("Output Channels"));
                        GUILayout.EndHorizontal();
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(OutputSampleRateProp, new GUIContent("Output Sample Rate"));
                        GUILayout.EndHorizontal();
                    }
                    GUILayout.EndVertical();
                }
            }
            GUILayout.EndVertical();


            GUILayout.Space(2);
            GUILayout.BeginVertical("box");
            {
                if (!MEncoder.EditorShowEncoded || !drawSuccess)
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("+ Encoded")) MEncoder.EditorShowEncoded = true;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                }
                else
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("- Encoded")) MEncoder.EditorShowEncoded = false;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(StreamFPSProp, new GUIContent("StreamFPS"));
                        GUILayout.EndHorizontal();
                    }
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(GZipModeProp, new GUIContent("GZip Mode"));
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        GUIStyle style = new GUIStyle();
                        style.normal.textColor = Color.yellow;
                        GUILayout.Label(" Experiment feature: Reduce network traffic", style);
                        GUILayout.EndHorizontal();
                    }
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(OutputFormatProp, new GUIContent("Output Format"));
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(OutputAsChunksProp, new GUIContent("Output As Chunks", "Split the data into small chunks, and recommended for UDP stream"));
                        GUILayout.EndHorizontal();
                        if (MEncoder.OutputAsChunks)
                        {
                            GUILayout.BeginHorizontal();
                            EditorGUILayout.PropertyField(OutputChunkSizeProp, new GUIContent("Output Chunk Size"));
                            GUILayout.EndHorizontal();
                        }
                    }
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        if (MEncoder.OutputFormat == AudioOutputFormat.FMPCM16)
                        {
                            EditorGUILayout.PropertyField(OnDataByteReadyEventProp, new GUIContent("OnDataByteReadyEvent"));
                        }
                        else
                        {
                            EditorGUILayout.PropertyField(OnRawPCM16ReadyEventProp, new GUIContent("OnRawPCM16ReadyEvent"));
                        }
                        GUILayout.EndHorizontal();
                    }
                    GUILayout.EndVertical();
                }
            }
            GUILayout.EndVertical();


            GUILayout.Space(2);
            GUILayout.BeginVertical("box");
            {
                if (!MEncoder.EditorShowPairing || !drawSuccess)
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("+ Pair Encoder & Decoder")) MEncoder.EditorShowPairing = true;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                }
                else
                {
                    GUILayout.BeginHorizontal();
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;
                    if (GUILayout.Button("- Pair Encoder & Decoder ")) MEncoder.EditorShowPairing = false;
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                    GUILayout.EndHorizontal();
                    GUILayout.BeginVertical("box");
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(labelProp, new GUIContent("label"));
                        GUILayout.EndHorizontal();


                        GUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(dataLengthProp, new GUIContent("Encoded Size(byte)"));
                        GUILayout.EndHorizontal();
                    }
                    GUILayout.EndVertical();
                }
            }
            GUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}