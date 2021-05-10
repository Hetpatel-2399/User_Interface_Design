using System;
using System.Runtime.InteropServices;  // DllImport()

namespace Chess
{
	 
	/// Summary description for Sounds.
	 
	public class Sounds
	{
		private string s_ParentFolder;
	
		// these are the SoundFlags we are using here, check mmsystem.h for more
		private int SND_ASYNC    = 0x0001;     // play asynchronously
		private int SND_FILENAME = 0x00020000; // use file name
		private int SND_PURGE    = 0x0040;     // purge non-static events

		public Sounds(string folder)
		{	
			s_ParentFolder=folder;
		}

		// Call the native Win32 API to play the sound
		[DllImport("WinMM.dll")]
		public static extern bool  PlaySound(string fname, int Mod, int flag);

		// Play the give sound file
		public void Play(string FileName)
		{
			int SoundFlags=SND_ASYNC | SND_FILENAME;
			PlaySound(FileName, 0, SoundFlags);
		}

		// Stop the running sound file and purge it from memory
		public void StopPlay()
		{
			PlaySound(null, 0, SND_PURGE);
		}

		// Play the click sound
		public void PlayClick()
		{
			StopPlay();
			Play(s_ParentFolder+"click.wav");
		}

		// Play the normal move sound
		public void PlayNormalMove()
		{
			StopPlay();
			Play(s_ParentFolder+"normal_move.wav");
		}

		// Play the capture move sound
		public void PlayCaptureMove()
		{
			StopPlay();
			Play(s_ParentFolder+"capture_move.wav");
		}

		// Play the under check sound
		public void PlayCheck()
		{
			StopPlay();
			Play(s_ParentFolder+"check.wav");
		}

		// Play the game over sound
		public void PlayGameOver()
		{
			StopPlay();
			Play(s_ParentFolder+"game_over.wav");
		}

	}
}
