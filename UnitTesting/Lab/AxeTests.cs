using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 1;
    private const int AxeDurability = 1;
    private const int DummyHealth = 10;
    private const int DummyExperiance = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(AxeAttack, AxeDurability);
        dummy = new Dummy(DummyHealth, DummyExperiance);
    }

    [Test]
    public void AxeAttackAndDurability_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(axe.AttackPoints, AxeAttack);
        Assert.AreEqual(axe.DurabilityPoints, AxeDurability);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);

        Assert.AreEqual(0, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}