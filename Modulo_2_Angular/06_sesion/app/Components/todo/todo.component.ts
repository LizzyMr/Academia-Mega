import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo',
  imports: [FormsModule, CommonModule],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent {

  nuevaTarea = "";

  tareas = [
    { texto : "Aprender Angular", completada: false},
    { texto : "Hacer Ejercicio", completada: true}
  ]

  agregarTareas(){
    if(this.nuevaTarea.trim()){
      this.tareas
      .push({texto: this.nuevaTarea, completada:false});
      this.nuevaTarea = "";
    }
  }

  limpiarTareas(){
    this.tareas = [];
  }

  toggleCompletar(index: number){
    this.tareas[index].completada = !this.tareas[index].completada;
  }
}
