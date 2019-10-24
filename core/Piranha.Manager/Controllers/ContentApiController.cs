/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha.Manager.Models;
using Piranha.Manager.Services;

namespace Piranha.Manager.Controllers
{
    /// <summary>
    /// Api controller for content management.
    /// </summary>
    [Area("Manager")]
    [Route("manager/api/content")]
    [Authorize(Policy = Permission.Admin)]
    [ApiController]
    public class ContentApiController : Controller
    {
        private readonly ContentTypeService _service;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContentApiController(ContentTypeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the currently available block types.
        /// </summary>
        /// <param name="parentType">The optional parent group type</param>
        /// <returns>The block list model</returns>
        [Route("blocktypes/{parentType?}")]
        [HttpGet]
        public BlockListModel GetBlockTypes(string parentType = null)
        {
            return _service.GetBlockTypes(parentType);
        }

        /// <summary>
        /// Creates a new block of the specified type.
        /// </summary>
        /// <param name="type">The block type</param>
        /// <returns>The new block</returns>
        [Route("block/{type}")]
        [HttpGet]
        public IActionResult CreateBlock(string type)
        {
            var block = _service.CreateBlock(type);

            if (block != null)
            {
                return Ok(block);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a new region for the specified content type.
        /// </summary>
        /// <param name="content">The type of content</param>
        /// <param name="type">The content type</param>
        /// <param name="region">The region id</param>
        /// <returns>The new region model</returns>
        [Route("region/{content}/{type}/{region}")]
        [HttpGet]
        public IActionResult CreateRegion(string content, string type, string region)
        {
            if (content == "page")
            {
                return Ok(_service.CreatePageRegion(type, region));
            }
            else if (content == "post")
            {
                return Ok(_service.CreatePostRegion(type, region));
            }
            else if (content == "site")
            {
                return Ok(_service.CreateSiteRegion(type, region));
            }
            return NotFound();
        }
    }
}