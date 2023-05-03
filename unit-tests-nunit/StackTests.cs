namespace unit_tests_nunit;

[TestFixture]
public class StackTests
{
    [Test]
    public void Push_ArgIsNull_ThrowsArgumentNullException()
    {
        var stack = new Stack<string>();

        Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
    }
    
    [Test]
    public void Push_ValidArg_AddTheObjectToTheStack()
    {
        var stack = new Stack<string>();
        
        stack.Push("a");
        
        Assert.That(stack.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void Count_EmptyStack_ReturnsZero()
    {
        var stack = new Stack<string>();
        
        Assert.That(stack.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void Pop_EmptyStack_ThrowsInvalidOperationException()
    {
        var stack = new Stack<string>();
        
        Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
    }
    
    [Test]
    public void Pop_StackWithAFewObjects_ReturnsObjectOnTheTop()
    {
        var stack = new Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        
        var result = stack.Pop();
        
        Assert.That(result, Is.EqualTo("c"));
    }
    
    [Test]
    public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
    {
        var stack = new Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        
        stack.Pop();
        
        Assert.That(stack.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void Peek_EmptyStack_ThrowsInvalidOperationException()
    {
        var stack = new Stack<string>();
        
        Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
    }
    
    [Test]
    public void Peek_StackWithObjects_ReturnsObjectOnTopOfTheStack()
    {
        var stack = new Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        
        var result = stack.Peek();
        
        Assert.That(result, Is.EqualTo("c"));
    }
    
    [Test]
    public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
    {
        var stack = new Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        
        stack.Peek();
        
        Assert.That(stack.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void Peek_StackWithObjects_ReturnsTheSameObjectAsPop()
    {
        var stack = new Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        
        var resultPeek = stack.Peek();
        var resultPop = stack.Pop();
        
        Assert.That(resultPeek, Is.EqualTo(resultPop));
    }
}