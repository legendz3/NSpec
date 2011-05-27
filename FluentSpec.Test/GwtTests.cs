using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using NUnit.Framework;

namespace FluentSpec.Test
{
    [TestFixture]
    public class BankKata
    {
        [Test]
        public void withdraw_test()
        {
            var spec = new Gwt<Account>();
            spec.Given(account => new Account())
                .When("Has 50 bucks", account => account.Balance = 50M)
                .Then("Should be able to withdraw 30 dollar", account => account.CanWithdraw(30M).should_be_true());
        }
    }

    public class Account
    {
        public decimal Balance { get; set; }
        public bool CanWithdraw(decimal amount)
        {
            return Balance >= amount;
        }
    }

}
