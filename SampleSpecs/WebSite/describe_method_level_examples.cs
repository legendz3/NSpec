﻿using NSpec;

class describe_method_level_examples : nspec
{
    void it_should_run_methods_that_start_with_IT_as_an_assertion()
    {
        @"this is a method level assertion (starts with ""it_"")".should_not_be_empty();
    }

    void specify_that_methods_that_start_with_SPECIFY_should_run_as_assertion()
    {
        @"this is a method level assertion (starts with ""specify_"")".should_not_be_empty();
    }
}

class describe_nested_classes : nspec
{
    protected string output = string.Empty;

    void before_each()
    {
        output += "root_class|";
    }

    void it_should_append_before_each()
    {
        output.should_be("root_class|");
    }

    class child_class : describe_nested_classes
    {
        void before_each()
        {
            output += "child_class|";
        }

        void it_should_append_before_each()
        {
            output.should_be("root_class|child_class|");
        }

        class child_child_class : child_class
        {
            void before_each()
            {
                output += "child_child_class|";
            }

            void it_should_append_before_each()
            {
                output.should_be("root_class|child_class|child_child_class|");
            }
        }
    }
}