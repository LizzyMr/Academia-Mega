# Sesión 13: Angular

## Fecha: 08/05/2025

## Objetivos de la Sesión

- Aprender a utilizar los pipes en Angular para trasnformar datos en las plantillas de manera sencilla y eficiente.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a routing en Angular.
   - Formularios en Angular.
   - Introducción a consumo de APIs con HTTP Client.
   - Manejo de estados con Services y Observables.
   - Implementación de un CRUD Completo.

## Ejercicios Realizados

### Ejercicio 13: .

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