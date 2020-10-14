﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public int id;
    public string info;
    public Sprite image;
    public Answer[] answers;
    public Knowledge correctKnowledge;
}
