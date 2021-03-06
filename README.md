# StudentAccounts
Задание: необходимо разработать приложение с использованием данных, представленных в файле Students.xml. Указанный файл содержит
следующие сведения о студентах: фамилия, имя, возраст, пол.

Требования.
Окно приложения должно предоставлять пользователю следующие возможности:
  1)	Отображение списка уже существующих элементов;
  2)	Создание нового элемента и добавление в список;
  3)	Редактирование любой записи в списке;   
  4)	Удаление одной и более записей из списка.

Требования к целостности данных:
  1)	Поля с именем, фамилией и полом обязательны для заполнения;
  2)	Возраст не может быть отрицательным и должен находиться в диапазоне [16, 100].

В случае нарушения целостности данных необходимо уведомлять пользователя об этом с указанием конкретного несоответствия требованиям к 
заполнению полей. 

Требования к дизайну:
  1)	Записи должны отображаться в виде списка с возможностью его прокрутки, если видимой области недостаточно для отображения всех 
элементов;
  2)	В случае, если количество записей в списке превышает одну, необходимо использовать для каждой четной и нечетной строки свою цветовую 
схему (максимум 2 цвета для любого числа записей);
  3)	Фамилия и имя должны отображаться в строке как единое целое;
  4)	Возраст должен отображаться в виде числа с постфиксом «года»/«лет»;
  5)	В случае отсутствия элементов в списке функционал редактирования и удаления должен быть недоступен, а вместо пустого списка должен 
отображаться другой шаблон, информирующий о том, что в списке нет элементов;
  6)	В случае удаления одного или более элементов из списка у пользователя должно запрашиваться подтверждение этого действия.
