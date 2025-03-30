using System;
using System.Collections;
using System.Collections.Generic;

public class IndexedPriorityQueue<T> : IEnumerable<T>
{
    private List<T> heap;
    private IComparer<T> comparer;

    public IndexedPriorityQueue() : this(null)
    {
    }

    public IndexedPriorityQueue(IComparer<T> comparer)
    {
        this.comparer = comparer ?? Comparer<T>.Default;
        heap = new List<T>();
    }

    public void Enqueue(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    public T Dequeue()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("IndexedPriorityQueue is empty.");

        var root = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        if (heap.Count > 0)
            HeapifyDown(0);
        return root;
    }

    public T Peek()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("IndexedPriorityQueue is empty.");
        return heap[0];
    }

    public T Find(Predicate<T> match)
    {
        if (match == null)
            throw new ArgumentNullException(nameof(match));
        foreach (T item in heap)
        {
            if (match(item))
                return item;
        }

        return default(T);
    }

    public List<T> FindAll(Predicate<T> match)
    {
        if (match == null)
            throw new ArgumentNullException(nameof(match));

        var results = new List<T>();
        foreach (T item in heap)
        {
            if (match(item))
                results.Add(item);
        }

        return results;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= heap.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            return heap[index];
        }
    }

    public int Count
    {
        get { return heap.Count; }
    }

    private void HeapifyUp(int index)
    {
        var parent = (index - 1) / 2;
        while (index > 0 && comparer.Compare(heap[index], heap[parent]) < 0)
        {
            Swap(index, parent);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    private void HeapifyDown(int index)
    {
        var lastIndex = heap.Count - 1;
        while (true)
        {
            var leftChild = index * 2 + 1;
            var rightChild = index * 2 + 2;
            var smallest = index;

            if (leftChild <= lastIndex && comparer.Compare(heap[leftChild], heap[smallest]) < 0)
                smallest = leftChild;
            if (rightChild <= lastIndex && comparer.Compare(heap[rightChild], heap[smallest]) < 0)
                smallest = rightChild;
            if (smallest == index)
                break;
            Swap(index, smallest);
            index = smallest;
        }
    }

    private void Swap(int i, int j)
    {
        (heap[i], heap[j]) = (heap[j], heap[i]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return heap.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return heap.GetEnumerator();
    }
}