const courses = document.querySelectorAll('.course');

for (const course of courses) {
    course.addEventListener('click', courseInfo);
}

function courseInfo(event) {
    const course = event.toElement;
    const courseId = course.id;

    const currentActive = document.getElementsByClassName('active');
    if (currentActive.length > 0) {
        currentActive[0].nextElementSibling.classList.remove('d-inline');
        currentActive[0].nextElementSibling.removeEventListener('click', deleteCourse());
        currentActive[0].className = currentActive[0].className.replace(' active', '');
    }

    this.className += ' active';
    this.nextElementSibling.classList.add('d-inline');
    this.nextElementSibling.addEventListener('click', deleteCourse);

    fetch(`/api/admin/AcademyApi/GetCourseInfo/${courseId}`)
        .then(response => response.json())
        .then(data => {
            fillLectures(data.lectures, data.courseId);
            fillExam(data.exam, data.courseId);
        });
}

function deleteCourse(event) {
    const courseId = event.toElement.previousElementSibling.id;

    fetch(`/api/admin/AcademyApi/DeleteCourse/${courseId}`,
        {
            method: 'delete'
        })
        .then(response => response.json())
        .then(data => location.reload());
}

function fillLectures(lectures, courseId) {
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
    addButton.classList.add('text-white');
    addButton.textContent = 'Create lecture';
    addButton.addEventListener('click', function (event) {
        createLectureForm(event, courseId);
    })

    parentDiv.appendChild(addButton);
}

function fillExam(exam, courseId) {
    const parentDiv = document.querySelector('.exam');
    parentDiv.innerHTML = '';

    if (!exam) {
        const addButton = document.createElement('a');
        addButton.classList.add('btn');
        addButton.classList.add('btn-success');
        addButton.textContent = 'Create exam';
        addButton.href = `/Administration/Academy/CreateExam/${courseId}`;

        parentDiv.appendChild(addButton);
        return;
    }

    const examP = document.createElement('p');
    const examA = document.createElement('a');

    examA.textContent = 'Edit exam';
    examA.classList.add('btn');
    examA.classList.add('btn-warning');
    examA.classList.add('ml-3');
    examA.href = `/Administration/Academy/EditExam/${courseId}`;

    examP.textContent = exam.name;
    examP.classList.add('lead');
    examP.appendChild(examA);

    parentDiv.appendChild(examP);
}

function createLectureForm(event, courseId) {
    const lecturesDiv = document.querySelector('.lectures');
    lecturesDiv.lastElementChild.classList.add('d-none');

    const parentDiv = document.createElement('div');
    const nameLabel = document.createElement('label');
    const nameInput = document.createElement('input');
    const validateSpan = document.createElement('span');
    const submitButton = document.createElement('a');

    nameLabel.htmlFor = 'name';
    nameLabel.className = 'm-3';
    nameLabel.textContent = 'Name';

    nameInput.type = 'text';
    nameInput.id = 'name';

    validateSpan.className = 'name-error text-danger';

    submitButton.classList.add('btn');
    submitButton.classList.add('btn-success');
    submitButton.classList.add('text-white');
    submitButton.classList.add('ml-2');
    submitButton.textContent = 'Create lecture';
    submitButton.addEventListener('click', function (event) {
        createLecture(event, courseId, nameInput.value);
    });

    parentDiv.appendChild(nameLabel);
    parentDiv.appendChild(nameInput);
    parentDiv.appendChild(validateSpan);
    parentDiv.appendChild(submitButton);

    lecturesDiv.appendChild(parentDiv);
    console.log(courseId);
}

function createLecture(event, courseId, nameInput) {
    if (nameInput && nameInput.length > 3) {
        console.log(nameInput);
        const formData = new FormData();
        formData.append('name', nameInput);

        fetch(`/api/admin/AcademyApi/CreateLecture/${courseId}`,
            {
                body: formData,
                method: 'post',
            })
            .then(response => response.json)
            .then(data => {
                if (data) {
                    location.reload();
                }
            });
    } else {
        document.querySelector('.name-error').textContent = 'Name cannot be empty or less than 4 symbols';
    }
}