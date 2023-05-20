import { Guid } from 'guid-typescript';

export interface User {
  userId: string;
  fullName: string;
  email: string;
  roleId: number;
  roleName?: string;
  password: string;
  isActive: number;
}
