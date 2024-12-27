
    using System;
    using System.Linq;
    using Xunit;
    using ScheduleManagement2;
    

namespace ScheduleManagementTests
{
    public class ScheduleManagerTests
        {
            [Fact]
            public void AddLesson_ShouldAddLessonToSchedule()
            {
                // Arrange
                var manager = new ScheduleManager();

                // Act
                manager.AddLesson("Math", "GroupA", "Mr. Smith", "101", new DateTime(2024, 01, 15, 10, 0, 0));

                // Assert
                var schedule = manager.GetFullSchedule();
                Assert.Single(schedule);
                Assert.Equal("Math", schedule.First().Name);
            }

            [Fact]
            public void GetScheduleForGroup_ShouldReturnChronologicalLessons()
            {
                // Arrange
                var manager = new ScheduleManager();
                manager.AddLesson("Math", "GroupA", "Mr. Smith", "101", new DateTime(2024, 01, 15, 10, 0, 0));
                manager.AddLesson("Physics", "GroupA", "Dr. Brown", "102", new DateTime(2024, 01, 15, 12, 0, 0));
                manager.AddLesson("Chemistry", "GroupB", "Dr. Green", "103", new DateTime(2024, 01, 16, 14, 0, 0));

                // Act
                var schedule = manager.GetScheduleForGroup("GroupA");

                // Assert
                Assert.Equal(2, schedule.Count);
                Assert.Equal("Math", schedule.First().Name);
                Assert.Equal("Physics", schedule.Last().Name);
            }

            [Fact]
            public void GetScheduleForDate_ShouldReturnLessonsForSpecificDate()
            {
                // Arrange
                var manager = new ScheduleManager();
                manager.AddLesson("Math", "GroupA", "Mr. Smith", "101", new DateTime(2024, 01, 15, 10, 0, 0));
                manager.AddLesson("Physics", "GroupA", "Dr. Brown", "102", new DateTime(2024, 01, 16, 12, 0, 0));

                // Act
                var schedule = manager.GetScheduleForDate(new DateTime(2024, 01, 15));

                // Assert
                Assert.Single(schedule);
                Assert.Equal("Math", schedule.First().Name);
            }

            [Fact]
            public void GetFullSchedule_ShouldReturnAllLessons()
            {
                // Arrange
                var manager = new ScheduleManager();
                manager.AddLesson("Math", "GroupA", "Mr. Smith", "101", new DateTime(2024, 01, 15, 10, 0, 0));
                manager.AddLesson("Physics", "GroupB", "Dr. Brown", "102", new DateTime(2024, 01, 16, 12, 0, 0));

                // Act
                var schedule = manager.GetFullSchedule();

                // Assert
                Assert.Equal(2, schedule.Count);
                Assert.Equal("Math", schedule.First().Name);
                Assert.Equal("Physics", schedule.Last().Name);
            }

            [Fact]
            public void GetScheduleForGroup_ShouldHandleEmptyGroup()
            {
                // Arrange
                var manager = new ScheduleManager();

                // Act
                var schedule = manager.GetScheduleForGroup("NonExistentGroup");

                // Assert
                Assert.Empty(schedule);
            }
        }
    }
