   M S B A M L   `   `   `  ���� E  AOtchetnost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Otchetnost
Otchetnost      Otchetnost.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Otchetnost       � Title$  
MainWindow��$	��700��$
��1200�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.��� -    �Name$ MainBar�����#9496CC.+��� -    ��Name$ Control�� �� TabStripPlacement$
 Left=�$��18(�
������ .@��� ���� .R��� $��20��$��20��$��0,5,0,5q�����  �� ImageSource$ Image/c.png��.����  �� Orientation$ 
Horizontal=�.+��� $	��300��.+��� -   
���� ��$��0q�
������ 
 � Tag$ 1��$��40��$��25,25q�$��Center=�$��Общий чат���� -   	 ��Name$	 	ChatPanel��$	��851��$��0,0,0,0q�.+��� -   
 ��Name$
 
ScrollChat��$	��590��.���� -   $
	 Chat��$ Vertical=�$��Bottom=��� $ 
Horizontal=�.+��� -    ��Name$ TextInputBox��
�������$��70��$	��700��$��20,20q��� -    ��Name$ 
ChatButton��
������ $��30��$��97��$��Center=�$��Отправить���� ���� .R��� $��20��$��20��$��0,5,0,5q����� $ Image/o.png��.���� $ 
Horizontal=�.+��� $	��330��.+��� -	   $		 fff��$ 
Horizontal=�.+��� $	��171��Группа�� Студент�� -
   $	 TaskSettings��$ 
Horizontal=�.+��� -    ��Name$ GroupBox�� �� 
IsEditable . $	��172��.@��� �� -   $ 
StudentBox�� . $	��155��.@��� �� $��0,5,0,0q�.+��� $��Hidden=�$��0,0,6,0q�$	��654��.���� -   $��ObjectsPanel��$��10,5,0,5q��� $	��820��.+��� -   $	 AddTasks��$ 
Horizontal=�$��50��.+��� $��20��.+��� -   $ 0��$��30(�+�� -   $	 AddTasksFields��$y�	Collapsed=�$ 
Horizontal=�.+��� -   $ TaskBox��$	��569���� $ Vertical=�.+��� $	��100��$��20�� �� TextAlignment$ Center=�
Deadline(  "System.Windows.Controls.DatePicker  -     Name$ Deadline��$	��150��$��15(�$��30���� -   
������ 
������ $��80��$��40��.��Add�� $
��Auto=�$	��640��.���� -   $	 
TasksPanel��$ Vertical=��� ���� .R��� $��20��$��20��$��0,5,0,5q����� $ Image/r.png��.���� .+��� -   $��ScheduleGroupBox�� . �� -   $	 
SchedUpper��$��Center=�$ 
Horizontal=�$	��310��$
��10,0q��� -   $	 
SchedLower��$��Center=�$ 
Horizontal=�$	��310��$��	10,15,0,0q��� ���� .R��� $��20��$��20��$��0,5,0,5q����� $ Image/p.png��.���� $ 
Horizontal=�.+��� $	��600��.+��� $ 
Horizontal=�$��35��.+��� $��Логин :���� -   $��	login_txt��$��empty���� $ 
Horizontal=�$��35��.+��� $��Статус :���� -   $��
status_txt��$��empty���� -   $	 UGroup��$ 
Horizontal=�$��35��.+��� $��Группа :���� -   $��	group_txt��$��empty���� -   $	 UnGroup��$ 
Horizontal=�$��37��.+��� $��Группа :���� -   $ ComboCourse��$��35��$	��Top=�$	��135���� -   $��Accept���� .+��� -   $��	0,540,0,0q�$#��Сменить аккаунт���� -     ��Name$ PrintOtchetnost��$y�	Collapsed=����� .R��� $��20��$��20��$��0,5,0,5q����� $ Image/f.png��.���� -!   $	 PrintOtchetnostPanel���� -"   $ UserSettings������ .R��� $��20��$��20��$��0,5,0,5q����� $ Image/s.png��.���� -#   $	 UserSettingsPanel��.+��� .@��� $4��.                Предмет               |��.���� .+��� -$   $	 AddDisciplinePanel��$��0,5,0,5q�$ 
Horizontal=�$��25��.+��� -%   $��AddDisciplineBoxxx��$��5,0,25,0q�$
��1050���� -&    ��Name$ AddDisciplineBtn��Send�� -'   $	 DisciplineList��$	��640���� $+��%            Группа            |��.���� -(   $	 	GroupList��$	��640���� $=��7              Предмет Группы             |��.���� $	��645��.+��� -)   $��EditGroupDisciplineBox�� . �� -*   $	 AddGroupDisciplineList��$��0,5,0,5q�$ 
Horizontal=�$��25��.+��� -+   $��AddDisciplineBox��$��5,0,5,0q�$	��500�� . �� -,   $��AddTeacherBox��$��40,0,5,0q�$	��500�� . �� --   $ AddGroupDiscipline��Отправить�� -.   $	 GroupDisciplineList��$	��610���� $[��U              Настройки пользователя                            ��.���� -/   $	 UserList��$ 
Horizontal=�$	��645��.+��� $	��550��.+��� Студент�� -0   $	 UserListStudent���� $	��550��.+��� Преподаватель�� -1   $ UserListStudentToTeacher�� . $��0,0,84,0q��� -2   $	 UserListTeacher���� �� -3   $��15(�$��Bottom=�$
��Left=�$��8, 5, 35, 30q����	#FF7C7C7C―�� -4   $��18(�$��Bottom=�$
��Left=�$��8, 5, 35, 5q����	#FFFF90A6⛌