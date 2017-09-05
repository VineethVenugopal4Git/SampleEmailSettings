using Microsoft.AspNetCore.Mvc;
using SampleEmailSettings.Entities;
using SampleEmailSettings.Extensions;
using SampleEmailSettings.Repository;
using SampleEmailSettings.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebApplicationBasic.Controllers
{

    public class EmailSettingController : Controller
    {
        private readonly IEmailSettings _emailRepo;
        public EmailSettingController(IEmailSettings emailRepo)
        {
            _emailRepo = emailRepo;
        }

        [HttpGet]
        public ApiResponse Get(Query queryObj)
        {
            var query = _emailRepo.GetAll().AsQueryable();
            int totalrecords = query.Count();
            try
            {
                var columnsMap = new Dictionary<string, Expression<Func<EmailTemplate, object>>>()
                {
                    ["Salutation"] = u => u.Salutation,
                    ["Subject"] = u => u.Subject,
                    ["Description"] = u => u.Description,
                    ["Signature"] = u => u.Signature,
                    ["id"] = u => u.Id
                };

                var details = query.ApplyOrdering(queryObj, columnsMap);
                details = query.ApplyPaging(queryObj);
                return new ApiResponse("SUCCESS", System.Net.HttpStatusCode.OK, totalrecords, details);
            }
            catch(Exception ex)
            {
                return new ApiResponse("FAILURE", System.Net.HttpStatusCode.BadRequest, 0, null, "Error while retriving Email Template");
            }
        }

        [HttpPost]

        public IActionResult Post([FromBody]EmailSetttingViewModel emailSettings)
        {
            try
            {
                var _emailTemplate = new EmailTemplate();
                if (emailSettings != null)
                {
                    _emailTemplate.Salutation = emailSettings.Salutation;
                    _emailTemplate.Subject = emailSettings.Subject;
                    _emailTemplate.Description = emailSettings.Description;
                    _emailTemplate.Signature = emailSettings.Signature;
                    _emailRepo.Add(_emailTemplate);
                    _emailRepo.commit();
                    return Ok(new { success = true, message = "Email Template Created" });
                }

                else
                {
                    return Ok(new { success = false, message = "Email Template Creation Failed" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Put([FromBody]EmailSetttingViewModel emailSettings)
        {

            try
            {
                var _emailTemplate = _emailRepo.GetEmail(emailSettings.Id);
                if (_emailTemplate != null)
                {
                    _emailTemplate.Salutation = emailSettings.Salutation;
                    _emailTemplate.Subject = emailSettings.Subject;
                    _emailTemplate.Description = emailSettings.Description;
                    _emailTemplate.Signature = emailSettings.Signature;
                    _emailRepo.update(_emailTemplate);
                    _emailRepo.commit();
                    return Ok(new { success = true, message = "Email Template Updated" });

                }
                else
                    return Ok(new { success = false, message = "Error while updating Email Template" });
            }
            catch (Exception ex)
            {
              
                return Ok(new { success = false, message = ex.Message });
            }



        }

        [HttpPost]
        public IActionResult Delete([FromBody]EmailSetttingViewModel emailSettings)
        {
            try
            {
                var _emailTemplate = _emailRepo.GetEmail(emailSettings.Id);
                if (_emailTemplate != null)
                {
                    
                   _emailRepo.Delete(_emailTemplate);
                    _emailRepo.commit(); 
                    return Ok(new { success = true, message = "Data was deleted" });
                }
                else
                    return Ok(new { success = false, message = "Error while deleting Email Template" });
            }
            catch (Exception ex)
            {
                
                return Ok(new { success = false, message = ex.Message });
            }


        }


    }
}
