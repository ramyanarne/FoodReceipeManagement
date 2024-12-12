import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeUnit'
})
export class TimeUnitPipe implements PipeTransform {

  transform(value: number): string {
    if(value > 0 && value/60 < 1){
      return `${value} mins`;
    }
    else{
      return `${value/60} hr`
    }
  }

}
