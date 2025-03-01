﻿namespace Composite;

/// <summary>
/// Component
/// </summary>
public abstract class FileSystemItem
{
    protected string Name { get; }
        
    public abstract long GetSize();

    protected FileSystemItem(string name)
    {
        Name = name;
    }
}


/// <summary>
/// Leaf
/// </summary>
public class File : FileSystemItem
{
    private readonly long _size;
    public File(string name, long size) : base(name) => _size = size;

    public override long GetSize() => _size;
}

/// <summary>
/// Composite
/// </summary>
public class Directory : FileSystemItem
{
    private readonly long _size;
    private readonly List<FileSystemItem> _fileSystemItems = new();
        
    public Directory(string name, long size) : base(name) => _size = size;

    public void Add(FileSystemItem itemToAdd) => _fileSystemItems.Add(itemToAdd);

    public void Remove(FileSystemItem itemToRemove) => _fileSystemItems.Remove(itemToRemove);

    public override long GetSize() => _size + _fileSystemItems.Sum(fileSystemItem => fileSystemItem.GetSize());
}