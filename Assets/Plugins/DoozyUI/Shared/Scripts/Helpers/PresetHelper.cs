using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DoozyUI
{
    public static partial class PresetHelper
    {
        public const string DEFAULT_PRESET_CATEGORY_NAME = "-- Category";
        public const string DEFAULT_PRESET_NAME = "-- Preset Name";
        public const string PRESET_EXTENSION = "dat";

#if UNITY_EDITOR
        /// <summary>
        /// Returns the preset file of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        /// <returns></returns>
        public static T GetPreset<T>(string directoryPath, string category, string presetName)
        {
            return FileHelper.GetFileAtPath<T>(directoryPath + "/" + category, presetName, PRESET_EXTENSION);
        }

        /// <summary>
        /// Saves a preset to the specified preset folder, under the specified category (subfolder) with the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="preset"></param>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        public static void SavePreset<T>(T preset, string directoryPath, string category, string presetName)
        {
            FileHelper.writeObjectToFile<T>(directoryPath + "/" + category + "/" + presetName + "." + PRESET_EXTENSION, preset, FileHelper.SerializeXML<T>);
        }

        /// <summary>
        /// Returns all the categories. (all the subfolder names from the presets folder)
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static string[] GetCategories(string directoryPath)
        {
            List<string> list = new List<string>() { DEFAULT_PRESET_CATEGORY_NAME };
            string[] c = FileHelper.GetSubfolderNamesAtPath(directoryPath);
            if (c != null && c.Length > 0)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    list.Add(c[i]);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Returns all the presetNames. (all the file names from a category folder)
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static string[] GetPresetNames(string directoryPath, string category)
        {
            List<string> list = new List<string>() { DEFAULT_PRESET_NAME };
            if (category.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME))
                return list.ToArray();
            string[] pn = FileHelper.GetFileNamesAtPath(directoryPath + "/" + category + "/", PRESET_EXTENSION);
            if (pn != null && pn.Length > 0)
            {
                for (int i = 0; i < pn.Length; i++)
                {
                    list.Add(pn[i]);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Creates a new category. (it creates a new folder under the presets folder)
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        public static void CreateCategory(string directoryPath, string category)
        {
            if (Directory.Exists(directoryPath + "/" + category))
                return;
            Directory.CreateDirectory(directoryPath + "/" + category);
        }

        /// <summary>
        /// Deletes a category and all of the presets under it. (it deletes a folder and all the files under it)
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        public static void DeleteCategory(string directoryPath, string category)
        {
            if (Directory.Exists(directoryPath + "/" + category))
                FileUtil.DeleteFileOrDirectory(directoryPath + "/" + category);
        }

        /// <summary>
        /// Deletes a preset from the specified category. (it deletes the preset file from the specified category)
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        public static void DeletePreset(string directoryPath, string category, string presetName)
        {
            FileUtil.DeleteFileOrDirectory(directoryPath + "/" + category + "/" + presetName + "." + PRESET_EXTENSION);
        }

        /// <summary>
        /// Retruns true if a preset was found and false otherwise.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        /// <returns></returns>
        public static bool DoesPresetExist(string directoryPath, string category, string presetName)
        {
            return FileHelper.fileExists(directoryPath + "/" + category + "/" + presetName + "." + PRESET_EXTENSION);
        }
#endif
    }
}
