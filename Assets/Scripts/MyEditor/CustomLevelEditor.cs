using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelTester))]
public class CustomLevelEditor : Editor
{
    private LevelTester _levelTester;
    private int 功能表 = 0;
    private string[] a = new String[] { "a", "b" };
    private Texture2D icon;

    private float[] floatfiledA = new float[] { 20,20.1f,20.2f};
    private int _selectedBG = 0;
    private string[] _bgOption = new string[] {"lvl1_朋友","lvl2_家人","lvl3_上司","lvl4_自我" };
    private int _NoteType = 0;
    private string[] _noteTypeName = new string[]{"點擊","滑動","按住(測試)"};
    private int _NoteSlideDir = 0;
    private string[] _NoteSlideDirName = new string[] { "向左滑", "向右滑" };
    public int _NoteDir = 0;
    private string[] _NoteDirName = new string[] {"方向左","方向右"};
    public int _NotePath = 0;
    public string[] _NotePathName = new string[] { "左1", "右1", "左2", "右2" };
    public override void OnInspectorGUI()
    {
        if (_levelTester == null)
        {
            _levelTester = (LevelTester)target;
        }
        
        功能表 = GUILayout.Toolbar(功能表,_levelTester.icon);
        GUILayout.Space(5);
        switch (功能表)
        {
            case 0:
                base.OnInspectorGUI();
                break;
            case 1:
                EditorGUI.BeginChangeCheck();
                this._selectedBG = EditorGUILayout.Popup("背景", _selectedBG,_bgOption);
                if (EditorGUI.EndChangeCheck())
                {
                    _levelTester.d_ChangeBG(_selectedBG);
                }
                break;
            case 2:
                GUILayout.Space(5);
                this._NoteType = GUILayout.Toolbar(_NoteType, _noteTypeName);
                GUILayout.Space(5);
                this._NoteDir = GUILayout.Toolbar(_NoteDir, _NoteDirName);
                GUILayout.Space(5);
                this._NoteSlideDir = GUILayout.Toolbar(_NoteSlideDir, _NoteSlideDirName);
                GUILayout.Space(5);
                this._NotePath = GUILayout.Toolbar(_NotePath, _NotePathName);
                GUILayout.Space(5);
                if (GUILayout.Button("生成音符"))
                {
                    if (Application.isPlaying == false)
                    {
                        Debug.Log("此功能止於許遊玩時測試");
                    }
                    else
                    {
                        Debug.Log($"生成 種類 {_noteTypeName[_NoteType]}, {_NoteDirName[_NoteDir]}, 路徑 {_NotePathName[_NotePath]}");
                        _levelTester.d_SpawnNote(_NoteType,_NoteDir,_NotePath,_NoteSlideDir);
                    }
                }
                break;
        }
        
    }
}
