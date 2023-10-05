﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab05.DAL.Entities;

namespace Lab05.BUS
{
    public class StudentService
    {
        public List<Student> GetAll()
        {
            StudentModel context = new StudentModel();
            return context.Students.ToList();
        }

        public List<Student> GetAllHasNoMajor()
        {
            StudentModel context = new StudentModel();
            return context.Students.Where(p => p.MajorID == null).ToList();
        }

        public List<Student> GetAllHasNoMajor(int facultyid)
        {
            StudentModel context = new StudentModel();
            return context.Students.Where(p => p.MajorID == null && p.FacultyID== facultyid).ToList();
        }

        public Student FindByID(string studentID)
        {
            StudentModel context = new StudentModel();
            return context.Students.FirstOrDefault(p => p.StudentID == studentID);
        }

        public void InsertUpdate(Student s)
        {
            StudentModel context = new StudentModel();
            context.Students.AddOrUpdate(s);
            context.SaveChanges();
        }

        public void RemoveByID(string studentID)
        {
            StudentModel context = new StudentModel();
            Student s = context.Students.FirstOrDefault(p => p.StudentID == studentID);
            if (s != null)
            {
                context.Students.Remove(s);
            }
            context.SaveChanges();
        }
    }
}
