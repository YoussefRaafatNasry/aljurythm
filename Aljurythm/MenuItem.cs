﻿using System;

namespace Aljurythm
{
    internal class MenuItem
    {
        internal enum PostActionMode
        {
            RE_PROMPT,
            START
        }

        public bool Condition = true;
        public string HotKey { get; set; }
        public string Text { get; set; }
        public Action Action { get; set; }
        public PostActionMode PostAction { get; set; } = PostActionMode.RE_PROMPT;

        public override string ToString()
        {
            return $"[{HotKey}] {Text}";
        }
    }
}
