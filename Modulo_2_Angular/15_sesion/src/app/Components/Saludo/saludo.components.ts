import { Component } from '@angular/core';

@Component({
    selector: "app-saludo",
    imports: [],
    template: `<h2>Hola, me llamo {{name}}</h2>`,
    styles: `
    h2{
        background-color: gray;
        color: white;
    }
    `
})

export class Saludo{
    name = "Lizeth Martínez"
}