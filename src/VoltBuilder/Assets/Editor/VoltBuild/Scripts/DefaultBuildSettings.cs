﻿using UnityEditor;
using UnityEngine;

namespace VoltBuilder
{
	public class DefaultBuildSettings : IBuildSettings
	{
		/// <inheritdoc/>
		public void DrawBuildSettings(BuildTool buildTool)
		{
			if (ConfigManager.GetBuildConfig(out DefaultBuildConfig config))
			{
				config.BuildTarget =
					(BuildTarget) EditorGUILayout.EnumPopup("Build Target:", config.BuildTarget);

				EditorGUILayout.BeginHorizontal();
				config.DevBuild = EditorGUILayout.Toggle("Dev Build", config.DevBuild);
				config.CopyPDBFiles = EditorGUILayout.Toggle("Copy PDB files", config.CopyPDBFiles);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.BeginHorizontal();
				config.ServerBuild = EditorGUILayout.Toggle("Server Build", config.ServerBuild);
				config.ZipFiles = EditorGUILayout.Toggle("Zip Build", config.ZipFiles);
				EditorGUILayout.EndHorizontal();

				if (GUILayout.Button("Save Settings"))
				{
					ConfigManager.SaveConfig();
				}
			}
			else
			{
				Debug.LogError("Build config is not the default one!");
			}
		}
	}
}