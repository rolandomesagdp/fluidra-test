import { Component, OnDestroy } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { FileExtensions } from '../file-extension.enum';
import { ProductFileServiceService } from '../product-file-service/product-file-service.service';
import { ProductsFile } from '../products-file.model';

@Component({
  selector: 'app-products-file-upload',
  templateUrl: './products-file-upload.component.html',
  styleUrls: ['./products-file-upload.component.scss']
})
export class ProductsFileUploadComponent implements OnDestroy {
  selectedFile: any = null;
  selectedFileName: string = "TheFileName";
  fileUploadSubscription: Subscription | undefined = undefined;

  constructor(private productsFileService: ProductFileServiceService, private _snackBar: MatSnackBar) { }

  onFileSelected(fileUploadEvent: any): void {
    this.selectedFile = fileUploadEvent.target.files[0] ?? null;
    const productsFile: ProductsFile = { fileName: this.selectedFile.name, fileExtension: FileExtensions.Json };
    this.fileUploadSubscription = this.productsFileService.uploadFile(productsFile).pipe(
      tap((productFile: ProductsFile) => {
        this._snackBar.open(`${productFile.fileName} was correctly uploaded`, "close")
      })
    ).subscribe();
  }

  ngOnDestroy(): void {
    if(this.fileUploadSubscription) {
      this.fileUploadSubscription.unsubscribe();
    }
  }
}

