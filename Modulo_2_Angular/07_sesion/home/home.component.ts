import { Component } from '@angular/core';
import { HijoComponent } from '../../Components/hijo/hijo.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [HijoComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  //Simulacion de API
  usuarios = [
    {nombre: "Juan", edad: 25, profesion: "Ingeniero"},
    {nombre: "Ana", edad: 23, profesion: "Diseñadora"},
    {nombre: "Luis", edad: 29, profesion: "Estudiante"},
    {nombre: "Omar", edad: 22, profesion: "Arquitecto"},
  ]
}
