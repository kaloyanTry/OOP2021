using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int health = 5;
    private const int experience = 10;

    private Dummy dummy;
    private Dummy dummyDead;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
        dummyDead = new Dummy(-5, experience);
    }

    [Test]
    public void Health_ShoulBeSetCorrectly()
    {
        Assert.AreEqual(dummy.Health, health);
    }

    [Test]
    public void WhenAttackedIsDead_ShouldThrowException()
    {
        Assert.That(() =>
        {
            dummyDead.TakeAttack(3); 
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    public void WhenIsAttacked_ShouldLoseHealth()
    {
        int attackePoints = 3;
        dummy.TakeAttack(attackePoints);

        Assert.AreEqual(dummy.Health, health - attackePoints);
    }

    [Test]
    public void WhenAliveGiveExperince_ShouldThrowException()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience();
        },  Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }

    [Test]
    public void WhenDead_ShouldGiveExperience()
    {
        Assert.That(dummyDead.GiveExperience(), Is.EqualTo(experience));
    }

    [Test]
    public void WhenHealthIsNegative_ShouldBeDead()
    {
        Assert.That(dummyDead.IsDead(), Is.EqualTo(true));
    }

    public void WhenHealthIsZero_ShouldBeDead()
    {
        dummy = new Dummy(0, experience);

        Assert.That(dummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void WhenHealthIsPossitive_ShouldBeAlive()
    {
        Assert.That(dummy.IsDead(), Is.EqualTo(false));
    }
}
