using FluentAssertions;
using Xunit;

namespace FluentAssertionsTest;

record struct MyRecordStruct(string[] strings);
record MyRecord(string[] strings);

public class Tests
{
    MyRecordStruct expectedRecordStruct = new (new [] { "a", "b" });
    MyRecordStruct actualRecordStruct = new (new [] { "a", "b" });

    MyRecord expectedRecord = new (new [] { "a", "b" });
    MyRecord actualRecord = new (new [] { "a", "b" });

    [Fact]
    public void RecordStruct_WithoutOptions()
    {
        actualRecordStruct.Should().BeEquivalentTo(expectedRecordStruct);
    }

    [Fact]
    public void RecordStruct_ComparingByMembers()
    {
        actualRecordStruct.Should().BeEquivalentTo(expectedRecordStruct, options => options.ComparingByMembers<MyRecordStruct>());
    }

    [Fact]
    public void RecordStruct_ComparingRecordsByMembers()
    {
        actualRecordStruct.Should().BeEquivalentTo(expectedRecordStruct, options => options.ComparingRecordsByMembers());
    }

    [Fact]
    public void Record_WithoutOptions()
    {
        expectedRecord.Should().BeEquivalentTo(actualRecord);
    }

    [Fact]
    public void Record_ComparingByMembers()
    {
        expectedRecord.Should().BeEquivalentTo(actualRecord, options => options.ComparingByMembers<MyRecord>());
    }

    [Fact]
    public void Record_ComparingRecordsByMembers()
    {
        expectedRecord.Should().BeEquivalentTo(actualRecord, options => options.ComparingRecordsByMembers());
    }
}