using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    [Trait("Category", "Unit")]
    public class StackShould
    {
        [Fact]
        public void have_count_of_zero_when_all_elements_are_popper()
        {
            int[] arr = new int[] { 1 };
            Stack<int> stack = new Stack<int>(arr);

            stack.Pop();

            Assert.Equal(0, stack.Pop());
        }

        [Fact]
        public void throw_exception_if_popped_when_empty()
        {
            var stack = new Stack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
    }

    public class EmptyStackExeption
    {

    }
}
