# Sesión 14: Angular

## Fecha: 09/05/2025

## Objetivos de la Sesión

- Aprender a utilizar los pipes en Angular para trasnformar datos en las plantillas de manera sencilla y eficiente.
- Utilizar todo lo aprendido durante el curso de Angular, para entregar un proyecto en forma. 

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a routing en Angular.
   - Formularios en Angular.
   - Introducción a consumo de APIs con HTTP Client.
   - Manejo de estados con Services y Observables.
   - Implementación de un CRUD Completo.

## Ejercicios Realizados

### Ejercicio 14: Implementación de Proyecto.

```ts
// user.service
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://randomuser.me/api/?results=10';
  
  constructor(private http: HttpClient) { }

  getUsers():Observable<any>{
    return this.http.get(this.apiUrl);

    console.log(this.apiUrl);
  }
}
```

```ts
// full-name.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'fullName'
})
export class FullNamePipe implements PipeTransform {

  transform(user: any): string {
    return `${user.name.title} ${user.name.first} ${user.name.last}`;
  }

}
```

```html
<!-- usuarios.component -->
<h1>Directorio de Usuarios</h1>
<div class="layout">
  <app-user-list (selectedUser)="user = $event"></app-user-list>
  <app-user-detail [user]="user"></app-user-detail>
</div>
```

```ts
import { Component } from '@angular/core';
import { UserListComponent } from '../../Components/user-list/user-list.component';
import { UserDetailComponent } from '../../Components/user-detail/user-detail.component';

@Component({
  selector: 'app-usuarios',
  imports: [UserListComponent, UserDetailComponent],
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class UsuariosComponent {
  user: any;
}
```

```css
h1 {
  text-align: center;
  margin-bottom: 2rem;
  color: rgb(19, 72, 125);
}

/* Layout principal */
.layout {
  display: flex;
  gap: 2rem;
  flex-wrap: wrap;
  justify-content: center;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  margin: 0;
  padding: 2rem;
  background-color: #3472b028;
  color: #333;
}
```

```html
<!-- user-list.component -->
<div *ngFor="let user of users" class="user-card" (click)="onSelect(user)">
  <img [src]="user.picture.medium" alt="Foto de {{ user | fullName }}">
  <div class="user-info">
    <h3>{{ user | fullName }}</h3>
    <p>{{ user.email }}</p>
  </div>
</div>
```

```ts
import { Component, EventEmitter, Output } from '@angular/core';
import { UserService } from '../../Service/user.service';
import { CommonModule } from '@angular/common';
import { FullNamePipe } from '../../Pipes/full-name.pipe';

@Component({
  selector: 'app-user-list',
  imports: [CommonModule, FullNamePipe],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  users: any[] = [];

  @Output() selectedUser = new EventEmitter();

  constructor(private userService: UserService){}

  ngOnInit(){
    this.userService.getUsers().subscribe(res => this.users = res.results);
    console.log(this.users);
  }

  onSelect(user: any){
    this.selectedUser.emit(user);
  }
}
```

```css
.user-card {
  background: #fff;
  border: 1px solid #e0e0e0;
  border-radius: 10px;
  padding: 1rem;
  width: 350px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
  cursor: pointer;
  transition: transform 0.2s, box-shadow 0.2s;
  display: flex;
  align-items: center;
  gap: 1rem;
}

.user-card:hover {
  transform: scale(1.02);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
}

.user-card img {
  border-radius: 50%;
  width: 60px;
  height: 60px;
}
```

```html
<!-- user-detail.component -->
<div *ngIf="user" class="user-detail">
  <img [src]="user.picture.large" alt="Foto de {{ user | fullName }}">
  <div class="info">
    <h2>{{ user | fullName }}</h2>
    <p><strong>Email:</strong> {{ user.email }}</p>
    <p><strong>Tel:</strong> {{ user.phone }}</p>
    <p><strong>Fecha Nac:</strong> {{ user.dob.date | date: 'longDate' }}</p>
    <p><strong>Edad:</strong> {{ user.dob.age }}</p>
    <p><strong>Ciudad:</strong> {{ user.location.city }}</p>
  </div>
</div>
```

```ts
import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FullNamePipe } from '../../Pipes/full-name.pipe';

@Component({
  selector: 'app-user-detail',
  imports: [CommonModule, FullNamePipe],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent {
  @Input() user:any;
}
```

```css
/* Detalle de usuario */
.user-detail {
  background: #fff;
  border: 1px solid #e0e0e0;
  border-radius: 10px;
  padding: 2rem;
  max-width: 400px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  flex: 1;
}

.user-detail img {
  width: 100%;
  border-radius: 10px;
  margin-bottom: 1rem;
}

.user-detail .info p {
  margin: 0.3rem 0;
}
```

## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- Curso de Angular 19 - Desde cero hasta profesional
- Angular - Formularios: curso intensivo (Angular 8+)
- Angular PRO desde cero: El curso definitivo (Angular 8+)
- RxJS nivel PRO
- Curso de Angular Avanzado: MEAN, JWT, Módulos, Animaciones

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre Angular, así como de JavaScript y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 8 del Módulo 2: Angular*