using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[Microsoft.VisualStudio.TestTools.UnitTesting.TestInitialize]
void Init()
{
    // Create the data source (needed to populate the Subjects collection)
    GradesPrototype.Data.DataSource.CreateData();
}

[TestMethod]
void TestValidGrade()
{
    GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "01/01/2012", "Math", "A-", "Very good");
    Assert.AreEqual(grade.AssessmentDate, "01/01/2012");
    Assert.AreEqual(grade.SubjectName, "Math");
    Assert.AreEqual(grade.Assessment, "A-");
}

[TestMethod]
[ExpectedException(typeof(ArgumentOutOfRangeException))]
void TestBadDate()
{
    // Attempt to create a grade with a date in the future
    GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2023", "Math", "A-", "Very good");
}

[TestMethod]
[ExpectedException(typeof(ArgumentException))]
void TestDateNotRecognized()
{
    // Attempt to create a grade with an unrecognized date
    GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "13/13/2012", "Math", "A-", "Very good");
}

[TestMethod]
[ExpectedException(typeof(ArgumentOutOfRangeException))]
void TestBadAssessment()
{
    // Attempt to create a grade with an assessment outside the range A+ to E-
    GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2012", "Math", "F-", "Terrible");
}

[TestMethod]
[ExpectedException(typeof(ArgumentException))]
void TestBadSubject()
{
    // Attempt to create a grade with an unrecognized subject
    GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "1/1/2012", "French", "B-", "OK");
}