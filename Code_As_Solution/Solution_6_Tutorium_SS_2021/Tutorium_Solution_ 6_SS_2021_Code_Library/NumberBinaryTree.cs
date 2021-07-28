using System;
using System.Collections.Generic;
using ClassLibrary_Solution_6_Tutorium_SS_2021;

namespace ClassLibrary_Solution_6_Tutorium_SS_2021
{
  public class NumberBinaryTree
  {

    #region Public property
    
    public int Count
    {
      get
      {
        int count = 0;
        CountCurrentNode(_root, ref count);
        return count;
      }
    }

    public int Maximum
    {
      get
      {
        int maximum = int.MinValue;

        Node currentNode = this._root;

        while (currentNode != null)
        {
          maximum = currentNode.Value > maximum ? currentNode.Value : maximum;
          currentNode = currentNode.Right;
        }

        return maximum;
      }
    }

    public int Minimum
    {
      get
      {
        int minimum = int.MaxValue;

        Node currentNode = this._root;

        while (currentNode != null)
        {
          minimum = currentNode.Value < minimum ? currentNode.Value : minimum;
          currentNode = currentNode.Left;
        }

        return minimum;
      }
    }

    #endregion

    #region Public method

    public void Insert(int number)
    {
      if (_root == null)
      {
        _root = new Node(number);
        return;
      }

      ProcessCurrentNode(number, _root);      
    }

    public int[] ReturnValues()
    {     
      var queue = new Queue<int>();
      
      AppendCurrentNode(queue, _root);

      var sortedQueueArray = queue.ToArray();      

      return sortedQueueArray;
    }
    
    #endregion

    #region Private variables

    private Node _root;
    
    #endregion

    #region Private Routines

    private void ProcessCurrentNode(int number, Node currentNode)
    {
      if (number == currentNode.Value)
      {
        return;
      }
      else if (number < currentNode.Value)
      {
        Node nextNode = currentNode.Left;
        if (nextNode == null)
        {
          currentNode.Left = new Node(number);
        }
        else
        {
          ProcessCurrentNode(number, nextNode);
        }
      }
      else
      {
        Node nextNode = currentNode.Right;
        if (nextNode == null)
        {
          currentNode.Right = new Node(number);
        }
        else
        {
          ProcessCurrentNode(number, nextNode);
        }
      }
    }


    private void AppendCurrentNode(Queue<int> queue, Node currentNode)
    {
      if (currentNode == null)
      {
        return;
      }
      else
      {
        AppendCurrentNode(queue, currentNode.Left);
        queue.Enqueue(currentNode.Value);
        AppendCurrentNode(queue, currentNode.Right);
      }
    }

    private void CountCurrentNode(Node currentNode, ref int currentCount)
    {
      if (currentNode == null)
      {
        return;
      }
      else
      {
        currentCount++;
        CountCurrentNode(currentNode.Left, ref currentCount);
        CountCurrentNode(currentNode.Right, ref currentCount);
      }
    }

    #endregion

    #region InnerClass

    private class Node
    {
      public int Value { get; set; }

      public Node Left { get; set; }
      public Node Right { get; set; }

      public Node(int value)
      {
        Value = value;
      }
    }

    #endregion
  }
}
