import { Injectable } from '@angular/core';
import { CommonEndpointService } from './common-endpoint.service';
import { User } from '../Model/User';
import { ResponseParamModel } from '../Model/Common/response-param.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private commonEndpoint: CommonEndpointService) { }

  GetUserByID(UserID : number){
    return this.commonEndpoint.PostNewEndpoint<User[]>(UserID,'api/Home/GetAllUserByID');
  }
  GetAllUser(){
    return this.commonEndpoint.getAllEndpoint<User[]>('api/Home/GetAllUsers');
  }
  AddUser(UserInfo:User){
    return this.commonEndpoint.PostNewEndpoint<ResponseParamModel>(UserInfo,'api/Home/Add');
  }
  UpdateUser(UserInfo:User){
    return this.commonEndpoint.PostNewEndpoint<ResponseParamModel>(UserInfo,'api/Home/Update');
  }

  delete(UserID:number){
    return this.commonEndpoint.PostNewEndpoint<ResponseParamModel>(UserID,'api/Home/Delete');
  }
}
