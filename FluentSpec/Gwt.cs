using System;
using NSpec;

namespace FluentSpec
{
    public class Gwt<TContext> : nspec where TContext : class
    {
        public TContext subject { get; set; }
        public Gwt<TContext> Given(Action<TContext> initializer)
        {
            before = () => initializer(subject);
            return this;
        }

        public Gwt<TContext> When(string contextDescription, Action<TContext> whenAction)
        {
            context[contextDescription] = () => whenAction(subject);
            return this;
        }

        public Gwt<TContext> Then(string contextDescription, Action<TContext> thenAction)
        {
            it[contextDescription] = () => thenAction(subject);
            return this;
        }


    }
}