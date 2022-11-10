CREATE SEQUENCE questions_id_seq;
create table questions
(
    Id integer NOT NULL DEFAULT nextval('questions_id_seq')
       constraint "questions_pk" primary key,
    Question    varchar(200),
    ImageUrl    varchar(255),
    ThumbUrl    varchar(255),
    PublishedAt timestamp
);

ALTER SEQUENCE questions_id_seq OWNED BY questions.Id;

insert into questions (Question, ImageUrl, ThumbUrl, PublishedAt)
values ('Favourite programming language?',
        'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)',
        'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)',
        '2015-08-05T08:40:51.620Z');


CREATE SEQUENCE Choices_id_seq;
create table choices
(
    Id integer NOT NULL DEFAULT nextval('choices_id_seq')
        constraint choices_pk primary key,
    IdQuestion integer constraint "choices_questions_idQuestion_fk" references questions (id),
    Choice     varchar(20),
    Votes      integer
);

ALTER SEQUENCE choices_id_seq OWNED BY choices.Id;

insert into choices (idquestion, choice, votes) values (1, 'Swift', 0);