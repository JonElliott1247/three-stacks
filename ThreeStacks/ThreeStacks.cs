using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeStacks
{
    public enum WhichStack
    {
        One,
        Two,
        Three
    }

    interface ThreeStacksInterface
    {
        void Push(int value, WhichStack whichStack);
        int Pop(WhichStack whichStack);
        int Peek(WhichStack whichStack);
        bool IsEmpty(WhichStack whichStack);
        bool IsFull(WhichStack whichStack);
    }

    public class ThreeStacks : ThreeStacksInterface
    {
        private int[] _intArray;
        private int[] _arrayStartIndex = new int[3];
        private int[] _stackCount = new int[3];


        private int _maxStackSize;
        public ThreeStacks(int arraySize)
        {
            _intArray = new int[arraySize];
            _arrayStartIndex[0] = 0;
            _arrayStartIndex[1] = (arraySize / 3);
            _arrayStartIndex[2] = ((arraySize / 3) * (2));
            _maxStackSize = arraySize / 3;


        }

        public bool IsEmpty(WhichStack whichStack)
        {
            switch (whichStack) {
                case WhichStack.One :
                    return (_stackCount[0] == 0);
                case WhichStack.Two :
                    return (_stackCount[1] == 0);
                case WhichStack.Three:
                    return (_stackCount[2] == 0);
                default: return false;
            }
        }

        public bool IsFull(WhichStack whichStack)
        {
            switch (whichStack) {
                case WhichStack.One: return !(_stackCount[0] < (_intArray.Length / 3));
                case WhichStack.Two: return !(_stackCount[1] < (_intArray.Length / 3));
                case WhichStack.Three: return !(_stackCount[2] < (_intArray.Length / 3));
                default: return false;
            }
        }

        public int Peek(WhichStack whichStack)
        {
            if (IsEmpty(whichStack))
            {
                return 0;
            }
            switch (whichStack) {
                case WhichStack.One: return _intArray[_arrayStartIndex[0] + _stackCount[0]];
                case WhichStack.Two: return _intArray[_arrayStartIndex[1] + _stackCount[1]];
                case WhichStack.Three: return _intArray[_arrayStartIndex[2] + _stackCount[2]];
                default: return 0;
            }
        }

        public int Pop(WhichStack whichStack)
        {
            int value;
            if(IsEmpty(whichStack)){
                return 0;
            }
            switch (whichStack) {
                case WhichStack.One:
                    value = _intArray[_arrayStartIndex[0] + _stackCount[0] - 1];
                    _stackCount[0]--;
                    return value;
                case WhichStack.Two:
                    value = _intArray[_arrayStartIndex[1] + _stackCount[1] - 1];
                    _stackCount[1]--;
                    return value;
                case WhichStack.Three:
                    value = _intArray[_arrayStartIndex[2] + _stackCount[2] - 1];
                    _stackCount[2]--;
                    return value;

                default:
                    return 0;
            }
        }

        public void Push(int value, WhichStack whichStack)
        {
            if (IsFull(whichStack)) {
                throw new Exception("Stack is Full");
            }
            switch(whichStack){
                case WhichStack.One:
                    _intArray[(_arrayStartIndex[0] + _stackCount[0])] = value;
                    _stackCount[0]++;
                    break;
                case WhichStack.Two:
                    _intArray[(_arrayStartIndex[1] + _stackCount[1])] = value;
                    _stackCount[1]++;
                    break;
                case WhichStack.Three:
                    _intArray[(_arrayStartIndex[2] + _stackCount[2])] = value;
                    _stackCount[2]++;
                    break;
                
            }
        }
    }
}
