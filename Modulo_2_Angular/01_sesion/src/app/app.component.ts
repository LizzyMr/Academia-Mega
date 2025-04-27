import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  titulo = 'Bienvenidos a mi página web';
  name = 'Lizeth Martínez';
  dato = 'Ing. Informática';
  edad = 25;
}
