using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    interface StackADT
    {

        /**
         * <summary>Push an item onto the top of the stack.</summary>
         * <returns>A reference to the object that was pushed, or null if newItem == null</returns>
         */
        Object Push(Object newItem);

        /**
         * <summary>Remove and return the item on the top of the stack.</summary>
         * <returns>A reference to the item that was popped (and removed) from the stack or null if the stack is empty</returns>
         */
        Object Pop();

        /** 
         * <summary>Return the top item but do not remove it.</summary>
         * <returns>A reference to the item on the top of the stack or null if the stack is empty</returns> 
         */
        Object Peek();

        /**
         * <summary>Check to see if the stack is empty or not.</summary>
         * <returns>True if the stack is empty, otherwise false</returns> 
         */
        bool IsEmpty();

        /**
         * <summary>Clear the stack. Does this by setting the head pointer to null.</summary>
         */
        void Clear();
    }
}
