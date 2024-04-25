import { HttpInterceptorFn } from '@angular/common/http';

export const logHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req);
};
