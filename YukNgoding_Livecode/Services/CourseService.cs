﻿using YukNgoding_Livecode.Entities;
using YukNgoding_Livecode.Repository;

namespace YukNgoding_Livecode.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IPersistence _persistence;

    public CourseService(ICourseRepository courseRepository, IPersistence persistence)
    {
        _courseRepository = courseRepository;
        _persistence = persistence;
    }

    public Course CreateNewCourse(Course course)
    {
        _persistence.BeginTransaction();
        try
        {
            var savedCourse = _courseRepository.Save(course);
            _persistence.SaveChanges();
            _persistence.Commit();
            return savedCourse;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }

    public Course? GetByName(string name)
    {
        try
        {
            var course = _courseRepository.FindByEmail(name);
            if (course is null) throw new Exception("Course Not Found!!");
            return course;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}