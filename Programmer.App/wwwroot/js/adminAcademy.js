﻿const courses = document.querySelectorAll('.course');

for (const course of courses) {
    course.addEventListener('click', courseInfo);
}

function courseInfo(event) {
    const course = event.toElement;
    const courseId = course.id;

    const current = document.getElementsByClassName("active");
    if (current.length > 0) {
        current[0].className = current[0].className.replace(" active", "");
    }

    this.className += " active";

    fetch(`/api/admin/AcademyApi/GetCourseInfo/${courseId}`)
        .then(response => response.json())
        .then(data => {
            fillLectures(data.lectures);
            fillExam(data.exam);
        });
}

function fillLectures(lectures) {
    const parentDiv = document.querySelector('.lectures');
    parentDiv.innerHTML = '';

    for (const lecture of lectures) {
        const lectureP = document.createElement('p');
        const lectureA = document.createElement('a');

        lectureA.textContent = 'Edit lecture';
        lectureA.classList.add('btn');
        lectureA.classList.add('btn-warning');
        lectureA.classList.add('ml-3');
        lectureA.href = `/Administration/.../Edit/${lecture.id}`;

        lectureP.textContent = lecture.name;
        lectureP.classList.add('lead');
        lectureP.appendChild(lectureA);

        parentDiv.appendChild(lectureP);
    }

    const addButton = document.createElement('a');
    addButton.classList.add('btn');
    addButton.classList.add('btn-success');
    addButton.textContent = 'Create lecture';
    addButton.href = '...';

    parentDiv.appendChild(addButton);
}

function fillExam(exam) {
    const parentDiv = document.querySelector('.exam');
    parentDiv.innerHTML = '';

    if (!exam) {
        addButton.classList.add('btn');
        addButton.classList.add('btn-success');
        addButton.textContent = 'Create exam';
        addButton.href = '...';

        parentDiv.appendChild(addButton);
        return;
    }


    const examP = document.createElement('p');
    const examA = document.createElement('a');
    const addButton = document.createElement('a');

    examA.textContent = 'Edit exam';
    examA.classList.add('btn');
    examA.classList.add('btn-warning');
    examA.classList.add('ml-3');
    examA.href = '.....';

    examP.textContent = exam.name;
    examP.classList.add('lead');
    examP.appendChild(examA);

    parentDiv.appendChild(examP);
}