import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.components';
import { CardComponent } from './Components/card/card.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Saludo, CardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  titulo = 'Bienvenidos a mi página web';
  name = 'Lizeth Martínez';
  dato = 'Ing. Informática';
  edad = 25;
}
