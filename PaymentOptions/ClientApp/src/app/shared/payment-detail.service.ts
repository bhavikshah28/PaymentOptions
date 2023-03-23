import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model'
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {

  formData: PaymentDetail = new PaymentDetail();
  readonly baseURL = "https://localhost:44349/api/paymentdetail";
  list: PaymentDetail[];

  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.baseURL).toPromise().then(res => this.list = res as PaymentDetail[]);
  }

  postPaymentDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  putPaymentDetail() {
    return this.http.put(`${this.baseURL}/${this.formData.paymentDetailId}`, this.formData);
  }

  deletePaymentDetail(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
