using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniCoursePlanning
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(',').ToList();
            string input;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] splittedInput = input.Split(':');
                string command = splittedInput[0];
                string lesson = splittedInput[1];

                if (command == "Add")
                {
                    if (!schedule.Contains(lesson))
                    {
                        schedule.Add(lesson);
                    } 
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(splittedInput[2]);

                    if (!schedule.Contains(lesson))
                    {
                        schedule.Insert(index, lesson);
                    }
                }
                else if (command == "Remove")
                {
                    if (schedule.Contains(lesson))
                    {
                        schedule.Remove(lesson);
                    }
                }
                else if (command == "Swap")
                {
                    string secondLesson = splittedInput[2];
                    string exercise = "{0}-Exercise";

                    if (schedule.Contains(lesson) && schedule.Contains(secondLesson))
                    {
                        int firstLessonIndex = schedule.IndexOf(lesson);
                        int secondLessonIndex = schedule.IndexOf(secondLesson);

                        string firstLessonExercise = $"{lesson}-Exercise";
                        string secondLessonExercise = $"{secondLesson}-Exercise";

                        bool hasFirstLessonExercise = false;
                        bool hasSecondLessonExercise = false;

                        if (schedule.Contains(firstLessonExercise))
                        {
                            int firstExerciseIndex = schedule.IndexOf(firstLessonExercise);
                            schedule.RemoveAt(firstExerciseIndex);
                            hasFirstLessonExercise = true;
                        }

                        if (schedule.Contains(secondLessonExercise))
                        {
                            int secondExerciseIndex = schedule.IndexOf(secondLessonExercise);
                            schedule.RemoveAt(secondExerciseIndex);
                            hasSecondLessonExercise = true;
                        }

                        if (hasFirstLessonExercise)
                        {
                            schedule.Insert(secondLessonIndex + 1, firstLessonExercise);
                        }

                        if (hasSecondLessonExercise)
                        {
                            schedule.Insert(firstLessonIndex + 1, secondLessonExercise);
                        }

                        schedule[firstLessonIndex] = secondLesson;
                        schedule[secondLessonIndex] = lesson;
                    }
                }
                else if (command == "Exercise")
                {
                    string exercise = $"{lesson}-Exercise";

                    if (!schedule.Contains(exercise))
                    {
                        if (schedule.Contains(lesson))
                        {
                            int indexLesson = schedule.IndexOf(lesson);
                            schedule.Insert(indexLesson + 1, exercise);
                        }
                        else
                        {
                            schedule.Add(lesson);
                            schedule.Add(exercise);
                        }
                    }
                }
            }

            int count = 1;

            foreach (var lesson in schedule)
            {
                Console.WriteLine($"{count}.{lesson}");
                count++;
            }
        }
    }
}
