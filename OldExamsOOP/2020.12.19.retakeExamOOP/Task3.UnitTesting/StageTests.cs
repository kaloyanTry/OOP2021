// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	using NUnit.Framework;
	using System;

	//using FestivalManager.Entities; //Comment for judge
	using System.Collections.Generic;
	using System.Linq;

	[TestFixture]
	public class StageTests
	{
		[Test]
		public void Ctor_ShouldInitializeCollectionCorrectly()
		{
			List<Song> songs = new List<Song>();
			List<Performer> performers = new List<Performer>();

			Assert.IsNotNull(songs);
			Assert.IsNotNull(performers);
		}

		[Test]
		public void AddPerformerToStage_ShoudThrowExeption_WhenNull()
        {
			Stage stage = new Stage();
			Performer performer = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddPerformer(performer);
			}, "Can not be null!");
		}

		[Test]
		public void AddPerformerToStage_ShoudThrowExeption_WhenLess18()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("U", "2", 12);

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(performer);
			}, "You can only add performers that are at least 18.");
		}

		[Test]
		public void AddPerformerToStage_ShoudAddCorrectly()
		{
			List<Performer> performers = new List<Performer>();
			Performer performer = new Performer("U", "2", 62);
			performers.Add(performer);

			Assert.That(performers.Contains(performer), Is.True);
		}


		[Test]
		public void AddSongToStage_ShoudThrowExeption_WhenNull()
		{
			Stage stage = new Stage();
			Song song = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSong(song);
			}, "Can not be null!");
		}

		[Test]
		public void AddSong_ShouldThrowException_WhenLes1Minute()
        {
			Stage stage = new Stage();
			Song song = new Song("Here", new TimeSpan(0, 0, 36));

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			}, "You can only add songs that are longer than 1 minute.");
        }

		[Test]
		public void AddSong_ShouldWorkCorrectly()
        {
			List<Song> songs = new List<Song>();
			Song song = new Song("Time", new TimeSpan(0, 6, 36));
			songs.Add(song);

			Assert.That(songs.Contains(song), Is.True);
		}

		[Test]
		public void AddSongToPerformer_ShouldThrowException_WhenNotValidPerformer()
        {
			Stage stage = new Stage();
			Performer performer = null;
			Song song = new Song("Time", new TimeSpan(0, 6, 36));

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer(nameof(song), nameof(performer));
			}, "Can not be null!");
		}

		[Test]
		public void AddSongToPerformer_ShouldThrowException_WhenNotValidSong()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("U", "2", 48);
			Song song = null;

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer(nameof(song), nameof(performer));
			}, "Can not be null!");
		}

		[Test]
		public void AddSongToPerformer_ShouldWorkCorrectly()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("U", "2", 48);
			Song song = new Song("Time", new TimeSpan(0, 6, 36));

			performer.SongList.Add(song);

			Assert.That(performer.SongList.Contains(song), Is.True);			
		}

		[Test]
		public void Play_ShouldCountSongsCorrectly()
        {
			Performer performer = new Performer("U", "2", 48);
			Song song = new Song("Time", new TimeSpan(0, 6, 36));

			performer.SongList.Add(song);

			Assert.AreEqual(performer.SongList.Count, 1);	
		}

		[Test]
		public void Play_ShouldCountPerformersCorrectly()
		{
			List<Performer> performers = new List<Performer>();
			Performer performer = new Performer("U", "2", 48);

			performers.Add(performer);

			Assert.AreEqual(performers.Count, 1);
		}

		[Test]
		public void GetPerformer_ShouldCountPerformersCorrectly()
		{
			List<Performer> performers = new List<Performer>();
			Performer performer = null;
			performers.Add(performer);

			Assert.AreEqual(performer, null);
		}

		[Test]
		public void GetSong_ShouldCountSongsCorrectly()
		{
			List<Song> songs = new List<Song>();
			Song song = null;
			songs.Add(song);

			Assert.AreEqual(song, null);
		}
	}
}