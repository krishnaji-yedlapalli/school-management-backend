# School Management Domain Models

This document serves as the primary reference for the domain entities and their relationships within the School Management System.

## 1. Overall Hierarchy
The system follows a strict academic hierarchy to ensure proper data isolation and logical grouping:
- **School** (Root)
    - **Class (Grade)**
        - **Section**
            - **Student**

### Additional Concepts
- **Subjects:** Defined at the **Class** level.
- **Teachers:** Assigned contextually (e.g., Class Teacher for a Class, Subject Teacher for a Section).

---

## 2. School
**Purpose:** The root aggregate defining institution identity and global configuration.

### Attributes
- `id`: UUID (Primary Key)
- `code`: Unique identifier (e.g., GVHS-01)
- `name`: Full school name
- `board`: Affiliation (e.g., CBSE, ICSE)
- `academicYear`: Current active year
- `grades`: List of grades offered
- `maxStudentsPerSection`: Default capacity
- `contact`: Email, Phone, Address details
- `operational`: Start/End Time, Working Days

---

## 3. Class (Grade)
**Purpose:** Represents an academic level within the school.

### Rules
- Belongs to **one** School.
- Can contain **multiple** Sections.
- Subjects are mapped at this level (not at the section level).

---

## 4. Section
**Purpose:** A subdivision of a Class for student grouping.

### Rules
- Belongs to **one** Class.
- **Students** belong to exactly one Section.
- **Teacher assignments** (Subject + Teacher) happen at this level.

---

## 5. Student
**Purpose:** An individual enrolled in the system.

### Rules
- Belongs to **one** Section.
- **Roll number** is unique within the Section.
- **Admission number** is unique within the School.

---

## 6. Subject-Teacher Assignment
- **Subject:** The academic topic (e.g., Math, Science).
- **Teacher:** The individual staff member.
- **Relationship:** A "many-to-many" logic handled via assignments. One teacher can teach multiple subjects across different sections.

---

## 7. Data Examples (JSON)

### School Example
```json
{
"id": "c3f9a9e4-7c12-4f6a-9b3d-91c8e1a2d001",
"code": "GVHS-01",
"name": "Green Valley High School",
"board": "CBSE",
"registrationNumber": "CBSE-REG-2023-98765",

"academicYear": "2024-2025",
"mediums": ["English", "Telugu"],
"grades": ["LKG", "UKG", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"],
"maxStudentsPerSection": 40,

"email": "info@greenvalleyschool.edu.in",
"phone": "+91-9876543210",
"addressLine1": "Near Central Park, MG Road",
"city": "Hyderabad",
"state": "Telangana",
"country": "India",
"pincode": "500081",

"startTime": "09:00",
"endTime": "16:00",
"workingDays": [1, 2, 3, 4, 5],
"timezone": "Asia/Kolkata",

"features": {
"attendanceEnabled": true,
"feesEnabled": true,
"examsEnabled": true,
"transportEnabled": false
},

"isActive": true,
"createdAt": "2024-04-01T10:15:30Z",
"updatedAt": "2024-09-15T08:45:00Z",
"createdBy": "system_admin"
}
```

### Class Example
```json
{
"id": "class_10",
"schoolId": "c3f9a9e4-7c12-4f6a-9b3d-91c8e1a2d001",

"name": "Grade 10",
"displayName": "10th Standard",
"order": 10,

"maxSections": 4,
"maxStudentsPerSection": 40,

"classTeacherId": "teacher_101",

"subjects": [
{ "subjectId": "sub_math", "isMandatory": true },
{ "subjectId": "sub_physics", "isMandatory": true },
{ "subjectId": "sub_chemistry", "isMandatory": true },
{ "subjectId": "sub_computers", "isMandatory": false }
],

"promotionsEnabled": true,
"isActive": true,

"createdAt": "2024-04-10T09:30:00Z",
"updatedAt": "2024-09-01T11:20:00Z"
}
```

### Section Example
```json
{
"id": "section_A",

"schoolId": "c3f9a9e4-7c12-4f6a-9b3d-91c8e1a2d001",
"classId": "class_10",

"name": "A",
"order": 1,

"maxStudents": 40,
"isActive": true,

"createdAt": "2024-04-12T09:00:00Z",
"updatedAt": "2024-09-01T10:00:00Z"
}
```

### Student Example
```json
{
"id": "student_1001",

"schoolId": "c3f9a9e4-7c12-4f6a-9b3d-91c8e1a2d001",
"classId": "class_10",
"sectionId": "section_A",

"firstName": "Ravi",
"lastName": "Kumar",
"gender": "Male",
"dateOfBirth": "2009-06-15",

"rollNumber": 12,
"admissionNumber": "ADM-2020-0456",
"academicYear": "2024-2025",

"guardianName": "Suresh Kumar",
"guardianPhone": "+91-9876543210",
"guardianEmail": "suresh.kumar@gmail.com",

"admissionDate": "2020-06-10",
"isActive": true,

"createdAt": "2024-04-15T08:30:00Z",
"updatedAt": "2024-09-01T10:45:00Z"
}
```

---

## 8. Implementation Notes for AI Agents
- **Architecture:** Use Repository Pattern + Clean Architecture.
- **Database:** SQLite (Primary).
- **Frontend:** Flutter + BLoC (Expected).
- **Security:** Multi-tenant support based on `schoolId`.
