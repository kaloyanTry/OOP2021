// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities; //comment for Judge
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
	using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private List<Song> songs;
		private List<Performer> performers;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
			songs = new List<Song>();
			performers = new List<Performer>();
        }

		[Test]
		public void Ctor_ShouldBeValidStage()
        {
			Assert.IsNotNull(stage);
			Assert.IsNotNull(songs);
			Assert.IsNotNull(performers);
		}


		[Test]
		public void ValidateNullValueShouldTrowException()
        {
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }


		[Test]
	    public void AddPerformerStage_ShouldThrowException_WhenUnder18()
	    {
			var performer = new Performer("Fil", "Kir", 2);

			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));
		}

		[Test]
		public void AddSongStage_ShouldThrowException_WhenUnder1()
		{
			var song = new Song("You", new TimeSpan(0, 0, 24));

			Assert.That(() => stage.AddSong(song), Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
		}

		[Test]
		public void AddSongToPerformer_ShouldWorkAll()
		{
			var song = new Song("You", new TimeSpan(0, 3, 00));
			var performer = new Performer("Fil", "Kir", 29);

			stage.AddSong(song);
			stage.AddPerformer(performer);

			var actual = stage.AddSongToPerformer("You", "Fil Kir");
			var expected = "You (03:00) will be performed by Fil Kir";

			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void AddSongToPerformer_ShouldThrowException_WhenNull()
        {
			var song = new Song("You", new TimeSpan(0, 3, 00));
			var performer = new Performer("Fil", "Kir", 29);

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Fill"));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("You", null));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, null));
		}

		[Test]
		public void Play_ShouldWorkCorrectly()
        {
			Song song1 = new Song("You", new TimeSpan(0, 3, 24));
			Song song2 = new Song("She", new TimeSpan(0, 2, 22));
			Performer performer = new Performer("Fil", "Kir", 29);

			stage.AddSong(song1);
			stage.AddSong(song2);

			stage.AddPerformer(performer);

			stage.AddSongToPerformer("You", "Fil Kir");
			stage.AddSongToPerformer("She", "Fil Kir");

			var actual = stage.Play();
			var expected = "1 performers played 2 songs";

			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void GetPerformer_ShouldCountCorrectlyPerformer()
		{
			var performer = new Performer("Fil", "Kir", 29);
			stage.AddPerformer(performer);

			Assert.That(stage.Performers.Count, Is.EqualTo(1));
		}

		[Test]
		public void ValidateNullSong_ShouldThrowException()
        {
			Assert.That(() => stage.AddSong(null), Throws.ArgumentNullException);
        }


		[Test]
		public void ValidateNullPerformer_ShouldThrowException()
		{
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}
	}
}