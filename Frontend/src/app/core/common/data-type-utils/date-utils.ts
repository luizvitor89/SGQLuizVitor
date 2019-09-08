import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'converteStringHoraParaDate' })
export class ConverteStringHoraParaDate implements PipeTransform {
  transform(hora: any) {
    if(typeof hora == "string"){
        let d = new Date(); 
        let [hours,minutes,seconds] = hora.split(':'); 
        d.setHours(+hours); 
        d.setMinutes(+minutes); 
        d.setSeconds(+seconds);
        return d;
    } else 
        return hora;
  }
}
