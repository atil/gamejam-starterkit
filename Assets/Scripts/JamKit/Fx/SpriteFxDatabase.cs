﻿using UnityEngine;

namespace JamKit
{
    [CreateAssetMenu(fileName = "SpriteDatabase", menuName = "Torreng/SpriteDatabase", order = 0)]
    public class SpriteDatabase : ScriptableObject
    {
        [SerializeField] private SpriteFx[] _allSpritesheets;

        public SpriteFx GetSpriteFx(string spritesheetName)
        {
            foreach (SpriteFx spriteList in _allSpritesheets)
            {
                if (spriteList.name == spritesheetName)
                {
                    return spriteList;
                }
            }

            Debug.Log($"Couldn't find spritesheet with name {spritesheetName}");
            return null;
        }
    }
}