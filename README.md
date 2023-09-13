Ważne! Instrukcja do uruchomienia projektu:
1.	Zainstalować Docker (Visual Studio 2022)
2.	Skopiuj repozytorium projektu git@github.com:nina-stefurak/StudentManagmentApp.git
3.	W głównym katalogu projektu należy wpisać docker-compose up --build
 
 
Żeby korzystać z aplikacji użytkownik musi najpierw zarejestrować się a potem załogować się. Na głównej stronie „Home” mamy buton „Register” i „Login”.
Przechodzimy do form Rejestracji i Logowania. 
 
Po zalogowaniu widzimy Stronę Powitalną, menu boczne. Po wcisnięciu na button „Create team” przechodzimy do Zarządzania zespołami, Po wcisnięciu na button „Create project” przechodzimy do strony Zarządzania projektami.

Na stronie „Team managment” jest możliwe tworzenie zespołów, edytowanie i usunięcie zespołów (przez leadera).
Z każdym projektem jest skojarzony zespół (nazwa, skład, lista wykonanych projektów). Użytkownik, który utworzył projekt jest jego leaderem, ale może oddać tę rolę innemu członkowi zespołu projektu.
Na stronie „Projects” jest możliwe dodawanie i edycja projektów (temat, opis, wymagania, liczba osób biorąca w projekcie, stos technologiczny, języki programowania, poziom trudności, data planowanego zakończenia, data oddania). 
Projekt może przechodzić przez kolejne stany: utworzony, skompletowany skład, rozpoczęty, ukończony etap/dodana funkcja, testowany, zakończony.
Ukończony projekt powinien zawierać link do repozytorium tzn. nie można ustawić statusu zakończenia bez linku. 
Do projektów otwartych można się zgłaszać. W projektach zamkniętych o składzie decyduje wyłącznie leader, ona dodaje członków zespołu. Na podstawie zgłoszeń do projektów otwartych leader wybiera członków zespołu projektu. 
Na stronie "Student Profile" jest zarządzanie profilem (edycja profilu w tym języki programowanie, znane biblioteki, frameworki, własna ocena umiejętności).
Admin ma dostęp do wszystkich użytkowników może zmieniać admina i dodawać admina.
