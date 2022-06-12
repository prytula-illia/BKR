import { Component, OnInit } from '@angular/core';
import { Code } from '../shared/models/code.model';
import { CompilerService } from '../shared/services/compiler.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-compiler',
  templateUrl: './compiler.component.html',
  styles: [
  ]
})
export class CompilerComponent implements OnInit {

  inputPlaceholder = "// Do not rename the Program class and Main method\n\n" +
  "using System;\n\n" +
  "public class Program\n" +
  "{\n" +	
  "        public static void Main()\n" +
  "        {\n" +
  "                Console.WriteLine(\"Hello, world!\");\n" +
  "        }\n" +
  "}";

  constructor(public service : CompilerService) { }

  ngOnInit(): void {
  }

  handleKeydown(event:any) {
    if (event.key == 'Tab') {
        event.preventDefault();
        var start = event.target.selectionStart;
        var end = event.target.selectionEnd;
        event.target.value = event.target.value.substring(0, start) + '\t' + event.target.value.substring(end);
        event.target.selectionStart = event.target.selectionEnd = start + 1;
    }
}

  compileCode(code : string) {
    Swal.fire('', 'Your code is compiling...');
    Swal.showLoading();
    this.service.compileCode(code).subscribe({
      next: (res : Code) => {
      var outputArea: HTMLElement = document.getElementById('output');
      outputArea.textContent = res.codeToCompile;
      Swal.close();
      }
    });
  }
}
