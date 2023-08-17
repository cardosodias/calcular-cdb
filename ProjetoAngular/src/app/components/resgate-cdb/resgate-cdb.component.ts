import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CdbResgateRequest } from 'src/app/models/cdb-resgate-request.model';
import { ResgateCdbService } from 'src/app/services/resgate-cdb.service';


@Component({
  selector: 'app-resgate-cdb',
  templateUrl: './resgate-cdb.component.html',
  styleUrls: ['./resgate-cdb.component.css'],
})
export class ResgateCdbComponent {
  constructor(private resgateCdbService: ResgateCdbService, private formBuilder: FormBuilder) 
  { }
  
  formulario!: FormGroup;
  canShow:boolean = false;
  canShowAlertaErro:boolean = false;
  valorBruno: number = 0;
  valorLiquido: number = 0;
  valorSolicitado:number = 0;
  
  

  ngOnInit(): void {
    this.canShow = false;
     this.formulario = this.formBuilder.group({
     valorResgate: [null, [Validators.required,Validators.min(0.01)]],
     quantidadeMes:[null,  [Validators.required,Validators.min(0.01)]]
     })
  }
    
  obj : CdbResgateRequest = new CdbResgateRequest();
   
  isFormValid(): boolean {
    return this.formulario.valid;
  };

  resgatarCdb() : void {
   
    if (this.formulario.valid){    

    this.obj.valorResgate = this.formulario.value.valorResgate;
    this.obj.qtdMes = this.formulario.value.quantidadeMes;;

    this.resgateCdbService.resgatarDois(this.obj).subscribe(
      (data) => {       

        //@ts-ignore
        this.valorBruno = data.valorBruto;
        //@ts-ignore
        this.valorLiquido = data.valorLiquido;
        this.valorSolicitado = this.formulario.value.valorResgate;
        this.canShow = true;
        this.formulario.reset();
      },
      (error) => {        
        this.canShow = false;
        this.canShowAlertaErro = true;
      }
    );
    }
  } 

  limparCdb():void{
    this.formulario.reset();
    this.canShow = false;
    this.canShowAlertaErro = false;
    this.valorBruno = 0;
    this.valorLiquido = 0;
  }
}
