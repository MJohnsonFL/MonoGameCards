using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameCards
{
    class Sound
    {
        List<SoundEffect> sounds = new List<SoundEffect>();

        internal void LoadContent(ContentManager Content)
        {
            sounds.Add(Content.Load<SoundEffect>("Sounds/cuckoo"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/draw"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/error"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/Passturn"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/playcard"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/rolldie"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/shuffle"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/stagechangeoldnotification"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/tap"));
            sounds.Add(Content.Load<SoundEffect>("Sounds/untap"));
        }

        public void Success() { sounds[0].Play(); }
        public void Draw() { sounds[1].Play(); }
        public void Error() { sounds[2].Play(); }
        public void PlayCard() { sounds[4].Play(); }
        public void Shuffle() { sounds[6].Play(); }
    }
}
